import os
import re
from sklearn.naive_bayes import MultinomialNB
from sklearn.metrics import accuracy_score
from sklearn.model_selection import train_test_split, GridSearchCV
import numpy as np
from sklearn.feature_extraction.text import CountVectorizer
import time


def getpaths() -> list[str]:
    #skiplist:list[str] = ['testall.py', 'results.txt']
    """
    This function traverses specific directories in the current directory and collects the paths of certain files.

    The function specifically looks for directories named 'chatGPT', 'copilot', and 'studentscodes'. 
    Within these directories, it navigates into any subdirectories it finds. 
    If a subdirectory named 'src' is found, the function collects the path of the first file in this 'src' directory.

    Returns
    -------
    list[str]
        A list of file paths collected from 'src' directories within 'chatGPT', 'copilot', and 'studentscodes' directories.
    """

    dir_list:list[str] = ['chatGPT','copilot','studentscodes']
    file_list:list[str] = []

    for directory in os.listdir('.'):
        if directory in dir_list:
            os.chdir(directory)
            dir_dir:list[str] = os.listdir('.')
            for dir in dir_dir:
                if os.path.isdir(dir):
                    os.chdir(dir)
                    dir_dir_dir:list[str] = os.listdir('.')
                    for file in dir_dir_dir:
                        if file == 'src':
                            os.chdir(file)
                            current_file:list[str] = os.listdir('.')
                            file_list.append(os.getcwd() + f'/{current_file[0]}')
                            os.chdir('..')
                    os.chdir('..')
            os.chdir('..')

    return file_list

def readfile(file:str) -> list[str]:
    """
    This function reads a file and performs several regular expression substitutions on its content.

    Parameters
    ----------
    file : str
        The path to the file to be read.

    Returns
    -------
    list[str]
        The content of the file as a list of strings, with certain patterns removed
    """

    new_line:list[str] = []
    with open(file, 'r',encoding='utf-8') as fr:
            line:str = fr.read()

            line = re.sub(r'/\*(.|\n)*?\*/', '', line)
            #line = re.sub(r'^.*\busing\b.*$', '', line, flags=re.MULTILINE)
            line = re.sub(r'//.*$', '', line, flags=re.MULTILINE)
            line = re.sub(r'^//.*$', '', line, flags=re.MULTILINE)
            #line = re.sub(r'System(?:\.[^.]+)+\.{2,}', '', line)
            #line = re.sub(r'\bint\b', '', line)
            #line = re.sub(r'[^a-zA-Z0-9/s]', ' ', line)
            #line = re.sub(r'using(?:\.[\w\d]+)?', '', line)
            #line = re.sub(r'\n{2,}', '\n', line)
            line = re.sub(r'\n{2,}', '\n', line, flags=re.MULTILINE)
            line = line.strip()
            #line = re.sub(r'\n\s*\n', '\n', line, flags=re.MULTILINE)
            line = re.sub(r'^[ \t]+','', line, flags=re.MULTILINE)
            line = re.sub(r' {2,}', ' ', line, flags=re.MULTILINE)
            line = re.sub(r'[{}]', '', line, flags=re.MULTILINE)
            line = re.sub(r'^.*\bclass\b.*$', '', line, flags=re.MULTILINE)
            line = re.sub(r'^.*\bstatic void Main\b.*$', '', line, flags=re.MULTILINE)
            line = line.replace('\ufeff','')
            #new_line = line.split()

    splitted_line = "\n".join([l for l in line.split("\n") if l.strip()])

    new_line = splitted_line.split('\n')
    #print(new_line)
    return new_line

    

def bayes(features:list[str], label:list[int]) -> None:
    """
    This function performs a Naive Bayes classification on the given features and labels.

    The function first vectorizes the features using CountVectorizer. It then splits the data into training, 
    validation, and test sets. A grid search is performed to find the best 'alpha' parameter for the 
    Multinomial Naive Bayes classifier.

    Parameters
    ----------
    features : list[str]
        The features to be used for training the classifier. Each element in the list is a string representing a feature.

    label : list[int]
        The labels corresponding to the features. Each element in the list is an integer representing a label.

    Returns
    -------
    None
    """
    print('Start bayes training...')
    vectorized = CountVectorizer()
    X = vectorized.fit_transform(features)
    X_train, X_test, y_train, y_test = train_test_split(X, label, test_size=0.2, random_state=54)
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
    """
    This function retrieves the paths of all .cs files in the 'testfiles' directory.

    Returns
    -------
    list[str]
        A list of file paths to .cs files in the 'testfiles' directory.
    """
    file_list:list[str] = []
    for file in os.listdir('makihyppy'):
        if file.endswith('.cs'):
            file_list.append(f'makihyppy/{file}')
    return file_list

def printresult(counthuman:int, countAI:int, file:str) -> None:
    total:int = counthuman + countAI
    pros:float = (counthuman/total)*100
    print(f'Human count: {counthuman}/{total} AI count: {countAI}/{total}')

    print(f'{file} is {pros:.2f}% human code')

    #for code, preds in zip(new_file, prediction):
     #   print(f'{code} : {preds}')


def main() -> None:
    """
    This function is the main entry point of the program.

    It first retrieves a list of file paths using the `getpath` function. It then reads each file in the list, 
    categorizing the words into two categories: 'humanwords' and 'aiwords', based on whether 'chatGPT' or 'copilot' 
    is in the file path. 

    The function then prints the length of 'humanwords' and 'aiwords'. 

    Finally, it combines 'humanwords' and 'aiwords' into a single list 'allcode', creates a corresponding list of labels, 
    and passes these to the `bayes` function for Naive Bayes classification.

    Returns
    -------
    None
    """

    filepath_list:list[str] = getpaths()        
    humanwords:list[str] = []
    aiwords:list[str] = []
    for file in filepath_list:
        if 'chatGPT' in file or 'copilot' in file:
            aiwords += readfile(file)
        else:
            humanwords += readfile(file)
            
    print(f'words len: {len(humanwords)} AI: {len(aiwords)}')

    labels:list[int] = [0]*len(humanwords) + [1]*len(aiwords)
    allcode:list[str] = humanwords + aiwords

    bayes(features=allcode, label=labels)

    
if __name__ == '__main__':
    main() 