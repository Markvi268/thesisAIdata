import os
import re
from sklearn.naive_bayes import MultinomialNB
from sklearn.metrics import accuracy_score
from sklearn.model_selection import train_test_split, GridSearchCV
import numpy as np
from sklearn.feature_extraction.text import CountVectorizer
import time

import bayes_file as bf
import bayes_lotto as bl
import bayes_hyppy as bh

def bayes(features:list[str], label:list[int]) -> None:

    print('Start bayes training...')
    vectorized = CountVectorizer()
    X = vectorized.fit_transform(features)
    X_train, X_test, y_train, y_test = train_test_split(X, label, test_size=0.2,random_state=42)
    #X_train, X_val, y_train, y_val = train_test_split(X_train, y_train, test_size=0.1, random_state=42)

    #print(f'X_train shape: {np.shape(X_train)}')
    #print(f'X_test shape: {np.shape(X_test)}')
    #print(f'X_val shape: {np.shape(X_val)}')

    params:dict[str,list[float]] = {'alpha': [0.01, 0.02, 0.03, 0.04, 0.05, 0.06, 0.07, 0.08, 0.09, 0.1, 0.2, 0.3, 0.5, 0.6, 0.7, 0.8, 0.9, 1.0, 1.5, 2.0, 3.0]}

    K_fold:int = 7
    model = MultinomialNB()
    classifier = GridSearchCV(estimator=model, param_grid=params, cv=K_fold)
    classifier.fit(X_train, y_train)

    best_param = classifier.best_params_
    best_model = MultinomialNB(alpha=best_param['alpha'])
    print(f'Best hyperparameter: {best_param}')
    print(f'Best score: {classifier.best_score_:.4f}')
    best_model.fit(X_train, y_train)
    y_pred = best_model.predict(X_test)
    print(f'Test data score best model: {best_model.score(X_test, y_test):.4f}')
    print(f'Test data accuracy: {accuracy_score(y_test, y_pred):.4f}')
    print('Training completed...')
    print()
    print('Testing new .cs file..')
    time.sleep(2)
    testfiles:list[str] = get_test_files()
    result_list:list[str] = []
    for file in testfiles:
        new_file = bf.readfile(file=file)
        X_test_data = vectorized.transform(new_file)
        prediction = best_model.predict(X_test_data)

        human_count = sum(1 for preds in prediction if preds == 0)
        ai_count = sum(1 for preds in prediction if preds == 1)
        total:int = human_count + ai_count
        pros:float = (human_count/total)*100
        f = file.split('/')[1]
        result_list.append(f'{f} is {pros:.2f}% human code')
        #printresult(human_count,ai_count, file=file.split('/')[1])

    writefile(result_list)

def get_test_files() -> list[str]:
    file_list:list[str] = []
    dir_list:list[str] = ['file_test_data','lotto_test_data','hyppy_test_data']
    for file in os.listdir('../'):
        if file in dir_list:
            os.chdir('../' + file)
            for i in os.listdir('.'):
                if i.endswith('.cs'):
                    file_list.append(os.getcwd() + f'/{i}')
                #os.chdir('..')
    os.chdir(os.path.dirname(__file__))
    return file_list

def printresult(counthuman:int, countAI:int, file:str) -> None:
    total:int = counthuman + countAI
    pros:float = (counthuman/total)*100
    #print(f'Human count: {counthuman}/{total} AI count: {countAI}/{total}')

    print(f'{file} is {pros:.2f}% human code')

def writefile(res_list:list[str]) -> None:
    print('Writing results to file...')
    with open('bayes_result.txt', 'w') as f:
        f.write('All training data results!\n\n')
        for res in res_list:
            f.write(res + '\n')
        f.write('0 % TARKOITTAA, ETTA ON 100% TEKOALYN TUOTTAMA KOODI')

def main() -> None:
    filepath_list:list[str] = bf.getpaths()
    filepath_list += bl.getpaths()
    filepath_list += bh.getpaths()        
    humanwords:list[str] = []
    aiwords:list[str] = []
    for file in filepath_list:
        if 'chatgpt' in file or 'copilot' in file:
            aiwords += bf.readfile(file)
        else:
            humanwords += bf.readfile(file)
            
    print(f'words len: {len(humanwords)} AI: {len(aiwords)}')

    labels:list[int] = [0]*len(humanwords) + [1]*len(aiwords)
    allcode:list[str] = humanwords + aiwords

    bayes(features=allcode, label=labels)

if __name__ == '__main__':
    main()