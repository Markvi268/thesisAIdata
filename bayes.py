import os
import re
from sklearn.naive_bayes import MultinomialNB
from sklearn.metrics import accuracy_score
from sklearn.model_selection import train_test_split
from collections import Counter
import numpy as np

            
if __name__ == '__main__':
    dir_list:list[str] = ['chatGPT','studentscodes']
    file_list:list[str] = []
    for directory in os.listdir('.'):
        if directory in dir_list:
            os.chdir(directory)
            files1 = os.listdir('.')
            for dir in files1:
                if os.path.isdir(dir):
                    os.chdir(dir)
                    files = os.listdir('.')
                    #print(files)
                    for f in files:
                        if f == 'src':
                            os.chdir(f)
                            f1 = os.listdir('.')
                            file_list.append(os.getcwd() + f'/{f1[0]}')
                            #readCode(file=os.getcwd() + f'/{f1[0]}')
                            os.chdir('..')
                    os.chdir('..')
            #print(files1)
            os.chdir('..')
    #print(file_list)
            

    words:list[str] = []
    for file in file_list:
        f=open(file, 'r',encoding='utf-8')
        line = f.read()
        line = re.sub(r'//.*', '', line)
        line = re.sub(r'/\*(.|\n)*?\*/', '', line)
        line = re.sub(r'[^a-zA-Z0-9/s]', ' ', line)
        line = re.sub(r'\busing\b', '', line)
        line = re.sub(r'\bSystem\b', '', line)
        words += line.split()
        f.close()
    print(len(words))

    for i in range(len(words)):
        if not words[i].isalpha():
            words[i] = ''

    word_dict:dict[str, int] = Counter(words)

    del word_dict['']
    print(len(word_dict))
    
    mostcommon_word = word_dict.most_common(150)

    label:list[int] = []
    features:list[list[int]] = []
    #print(mostcommon_word)
    for e in file_list:
        try:
            f=open(e, 'r',encoding='utf-8')
            line = f.read()
            line = re.sub(r'//.*', '', line)
            line = re.sub(r'/\*(.|\n)*?\*/', '', line)
            line = re.sub(r'[^a-zA-Z0-9/s]', ' ', line)
            line = re.sub(r'\busing\b', '', line)
            line = re.sub(r'\bSystem\b', '', line)
            new_line = line.split()
            data:list[int] = []

            sana = 'for'
            j:int=0
            for i in mostcommon_word:
                data.append(new_line.count(i[0]))
            features.append(data)
            
            
            if "lottoTaulukko" in line or "lottoRivi" in line or "lottoNumbers" in line or "lotteryNumbers" in line:
                label.append(1)
            elif line.count(sana) >= 3:
                label.append(1)
            else:
                label.append(0)
            f.close()

        except:
            print(f'Error with file: {e}')
            continue

    print(label)
    print(f'features len: {len(features)}')
    print(f'label len: {len(label)}')

    featuresnp = np.array(features)
    print(f'features shape: {np.shape(featuresnp)}')

    labelnp = np.array(label)
    print(f'label shape: {np.shape(labelnp)}')

    X_train, X_test, y_train, y_test = train_test_split(featuresnp, labelnp, test_size=0.1)

    print(f'X_train shape: {np.shape(X_train)}')
    print(f'X_test shape: {np.shape(X_test)}')

    model = MultinomialNB()
    model.fit(X_train, y_train)
    MultinomialNB(alpha=1.0, class_prior=None, fit_prior=True)

    new_file = ''
    path = 'solution/s1/src/s1.cs'
    #path = 'chatGPT/AItest01/src/testcode1.cs'
    with open(path, 'r') as f:
        line = f.read()
        line = re.sub(r'//.*', '', line)
        line = re.sub(r'/\*(.|\n)*?\*/', '', line)
        line = re.sub(r'[^a-zA-Z0-9/s]', ' ', line)
        line = re.sub(r'\busing\b', '', line)
        line = re.sub(r'\bSystem\b', '', line)
        new_file = line
    
    n = new_file.split()
    sample:list[int] = []
    for i in mostcommon_word:
        sample.append(n.count(i[0]))

    samplenp = np.array(sample)
    print(f'sample: {sample}')

    model.predict(np.reshape(samplenp, (1, 110)))

    y_pred:list[str] = model.predict(X_test)

    print(accuracy_score(y_test, y_pred))
    

