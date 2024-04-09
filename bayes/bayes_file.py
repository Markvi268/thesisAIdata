import os
import re
from sklearn.naive_bayes import MultinomialNB
from sklearn.metrics import accuracy_score
from sklearn.model_selection import train_test_split, GridSearchCV
import numpy as np
from sklearn.feature_extraction.text import CountVectorizer
import time


def getpaths() -> list[str]:
    original_path:str = os.path.dirname(__file__)
    parent_path:str = os.path.dirname(original_path)
    dir_list:list[str] = ['chatgpt_train_data','copilot_train_data','students_train_data']
    file_list:list[str] = []
    current_dir:str = 'file_train_data'

    for directory in os.listdir('../'):
        if directory == current_dir:
            #Mennään /hyppy_train_data hakemistoon
            os.chdir('../' + directory)
            for dir in os.listdir('.'):
                if os.path.isdir(dir):
                    os.chdir(dir)
                    for file in os.listdir('.'):
                        if os.path.isdir(file):
                            os.chdir(file)
                            for f in os.listdir('.'):
                                if f == 'src':
                                    os.chdir(f)
                                    current_file:list[str] = os.listdir('.')
                                    file_list.append(os.getcwd() + f'/{current_file[0]}')
                                    os.chdir('..')
                            os.chdir('..')
                    os.chdir('..')

    os.chdir(original_path)
    return file_list

def readfile(file:str) -> list[str]:

    new_line:list[str] = []
    with open(file, 'r',encoding='utf-8') as fr:
            line:str = fr.read()

            line = re.sub(r'/\*(.|\n)*?\*/', '', line)
            line = re.sub(r'//.*$', '', line, flags=re.MULTILINE)
            line = re.sub(r'^//.*$', '', line, flags=re.MULTILINE)
            line = re.sub(r'\n{2,}', '\n', line, flags=re.MULTILINE)
            line = line.strip()
            line = re.sub(r'^[ \t]+','', line, flags=re.MULTILINE)
            line = re.sub(r' {2,}', ' ', line, flags=re.MULTILINE)
            line = re.sub(r'[{}]', '', line, flags=re.MULTILINE)
            line = re.sub(r'^.*\bclass\b.*$', '', line, flags=re.MULTILINE)
            line = re.sub(r'^.*\bstatic void Main\b.*$', '', line, flags=re.MULTILINE)
            line = line.replace('\ufeff','')

    splitted_line = "\n".join([l for l in line.split("\n") if l.strip()])

    new_line = splitted_line.split('\n')
    return new_line

    

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
    for file in testfiles:
        new_file = readfile(file=file)
        X_test_data = vectorized.transform(new_file)
        prediction = best_model.predict(X_test_data)

        human_count = sum(1 for preds in prediction if preds == 0)
        ai_count = sum(1 for preds in prediction if preds == 1)

        printresult(human_count,ai_count, file=file.split('/')[1])

def get_test_files() -> list[str]:
    file_list:list[str] = []
    for file in os.listdir('../'):
        if file == 'file_test_data':
            os.chdir('../' + file)
            for i in os.listdir('.'):
                if i.endswith('.cs'):
                    file_list.append(os.getcwd() + f'/{i}')
    return file_list

def printresult(counthuman:int, countAI:int, file:str) -> None:
    total:int = counthuman + countAI
    pros:float = (counthuman/total)*100
    print(f'Human count: {counthuman}/{total} AI count: {countAI}/{total}')

    print(f'{file} is {pros:.2f}% human code')


def main() -> None:
    
    filepath_list:list[str] = getpaths()        
    humanwords:list[str] = []
    aiwords:list[str] = []
    for file in filepath_list:
        if 'chatgpt' in file or 'copilot' in file:
            aiwords += readfile(file)
        else:
            humanwords += readfile(file)
            
    print(f'words len: {len(humanwords)} AI: {len(aiwords)}')

    labels:list[int] = [0]*len(humanwords) + [1]*len(aiwords)
    allcode:list[str] = humanwords + aiwords

    bayes(features=allcode, label=labels)

    
if __name__ == '__main__':
    main()