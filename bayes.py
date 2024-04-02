import os
import re
from sklearn.naive_bayes import MultinomialNB
from sklearn.metrics import accuracy_score
from sklearn.model_selection import train_test_split
from collections import Counter
import numpy as np


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

            line = re.sub(r'//.*', '', line)
            line = re.sub(r'/\*(.|\n)*?\*/', '', line)
            line = re.sub(r'System(?:\.[\w\d]+)?', '', line)
            line = re.sub(r'[^a-zA-Z0-9/s]', ' ', line)
            line = re.sub(r'\busing\b', '', line)
            new_line = line.split()
    return new_line



def bayes(features:list[list[int]], label:list[int], mostcommon_word:dict[str,int]) -> None:

    featuresnp = np.array(features)
    print(f'features shape: {np.shape(featuresnp)}')

    labelnp = np.array(label)
    print(f'label shape: {np.shape(labelnp)}')

    X_train, X_test, y_train, y_test = train_test_split(featuresnp, labelnp, test_size=0.2)

    print(f'X_train shape: {np.shape(X_train)}')
    print(f'X_test shape: {np.shape(X_test)}')

    model = MultinomialNB()
    model.fit(X_train, y_train)
    #MultinomialNB(alpha=1.0, class_prior=None, fit_prior=True)

    path = 'solution/s1/src/s1.cs'
    #path = 'copilot/AItest05/src/testcode5.cs'
   
    new_file = readfile(path)
    
    sample:list[int] = []
    for word in mostcommon_word:
        sample.append(new_file.count(word[0]))

    model.predict(np.reshape(np.array(sample), (1, len(X_train[1]))))

    y_pred = model.predict(X_test)

    print(f'{accuracy_score(y_test, y_pred):.2f}')



def main() -> None:

    file_list:list[str] = getpath()        

    words:list[str] = []
    for file in file_list:
            words += readfile(file)

    print(f'words len: {len(words)}')

    for word in range(len(words)):
        if not words[word].isalpha():
            words[word] = ''

    word_dict:dict[str, int] = Counter(words)

    del word_dict['']
    print(f'word_dict len: {len(word_dict)}')
    N_word_min:int = 30

     # Dictionary words that occur at least N_word_min times 
    mostcommon_word = {word: occur for word,occur in word_dict.items() if occur > N_word_min}
    #orded_mostcommon_words = sorted(mostcommon_word.items(), key = lambda x: x[1], reverse = True)

    label:list[int] = []
    features:list[list[int]] = []
    #print(mostcommon_word)
    for file in file_list:
        new_line = readfile(file)
        data:list[int] = []

        for word in mostcommon_word:
            data.append(new_line.count(word[0]))
        features.append(data)
            
        if 'chatGPT' in file or 'copilot' in file:
            label.append(1)
        else:
            label.append(0)

    #print(label)
    print(f'features len: {len(features)}')
    print(f'label len: {len(label)}')

    bayes(features=features, label=label,mostcommon_word=mostcommon_word)

    
if __name__ == '__main__':
    main()

    

   
    

