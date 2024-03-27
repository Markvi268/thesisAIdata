import os
import re


def getpath() -> list[str]:
    dir_list:list[str] = ['chatGPT']
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

def readfile(file:str) -> set[str]:

    words:list[str] = []
    with open(file,'r') as fr:
            line:str = fr.read()
            
            line = re.sub(r'//.*', '', line)
            line = re.sub(r'/\*(.|\n)*?\*/', '', line)
            line = re.sub(r'System(?:\.[\w\d]+)?', '', line)
            line = re.sub(r'[^a-zA-Z0-9/s]', ' ', line)
            line = re.sub(r'\busing\b', '', line)
            words += line.split()

    for word in range(len(words)):
        if not words[word].isalpha():
            words[word] = ''

    words.sort()
    words_set = {word for word in words if word !=''}
    return words_set



def similars() -> None:
    paths:list[str] = getpath()
    resultsfile=open('similars.txt','wt')
    
    for i in range(len(paths) - 1):
        first_file:set[str] = readfile(paths[i])
        sim:int=0
        for j in range(1, len(paths) - i):
            sim = 0
            second_file:set[str] = readfile(paths[j+i])

            for word in first_file:
                for simword in second_file:
                    if word == simword:
                        sim = sim + 1


            pros:float = sim/(len(first_file)+len(second_file))*100*2
            first_path_rep = paths[i].replace('/',' ').replace('\\', ' ')
            first_path_list:list[str] = first_path_rep.split()

            path_rep = paths[j+i].replace('/',' ').replace('\\', ' ')

            path_list:list[str] = path_rep.split()

            #resultsfile.write(f'{path_list[10]}\n')
            resultsfile.write(f'Tiedoston {first_path_list[10]} ja tiedoston {path_list[10]} valilla samoja sanoja on: {pros:.2f} % \n')

    resultsfile.close()



def main() -> None:
    similars()
 

if __name__ == '__main__':
    main()