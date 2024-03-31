import os
import re
from sklearn.naive_bayes import MultinomialNB
from sklearn.metrics import accuracy_score
from sklearn.model_selection import train_test_split
import numpy as np
from sklearn.feature_extraction.text import CountVectorizer


def getpath() -> list[str]:

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
            new_line = line.split()
    splitted_line = "\n".join([rivi for rivi in line.split("\n") if rivi.strip()])
    new_line = splitted_line.split('\n')
    #print(splitted_line)
    return new_line



def bayes(features:list[str], label:list[int]) -> None:

    
    vectorized = CountVectorizer()
    X = vectorized.fit_transform(features)
    X_train, X_test, y_train, y_test = train_test_split(X, label, test_size=0.2)

    print(f'X_train shape: {np.shape(X_train)}')
    print(f'X_test shape: {np.shape(X_test)}')

    model = MultinomialNB()
    model.fit(X_train, y_train)
    MultinomialNB(alpha=1.0, class_prior=None, fit_prior=True)

    #path = 'solution/s1/src/s1.cs'
    #path = 'copilot/AItest05/src/testcode5.cs'
    path = 'aitest.cs'
    #path = 'studentscodes/code18/src/Tehtava_4.cs'
    print(f'Classifier score: {model.score(X_test, y_test):.5f}')
    new_file = readfile(path)
    

    X_test_data = vectorized.transform(new_file)

    pred = model.predict(X_test_data)

    human_count = sum(1 for preds in pred if preds == 0)
    ai_count = sum(1 for preds in pred if preds == 1)
    print(f'Human count: {human_count} AI count: {ai_count}')
    if human_count > ai_count:
        print('This is a human code')
    else:
        print('This is a AI code')

    #for code, preds in zip(new_file, pred):
     #   print(f'{code} : {preds}')

def main() -> None:

    file_list:list[str] = getpath()        

    humanwords:list[str] = []
    aiwords:list[str] = []
    for file in file_list:
        if 'chatGPT' in file or 'copilot' in file:
            aiwords += readfile(file)
            #print(nonhumanwords)
            #break
        else:
            humanwords += readfile(file)
            #print(humanwords)
            #break

    print(f'words len: {len(humanwords)} AI: {len(aiwords)}')
    #print(humanwords)
    #print(file_list)

    labels:list[int] = [0]*len(humanwords) + [1]*len(aiwords)
    allcode:list[str] = humanwords + aiwords
    #print(labels)

    bayes(features=allcode, label=labels)

    
if __name__ == '__main__':
    main() 