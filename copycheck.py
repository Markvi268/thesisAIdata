import os
import re
from collections import Counter
import math

def getsecondpath() -> list[str]:
    original_path:str = os.getcwd()
    dir_list:list[str] = ['assignments']
    file_list:list[str] = []
    path:str = 'C:/Users/Markku/Desktop/Markku_Koulu/Harkka/pythontest/'
    for directory in os.listdir(path):
        if directory in dir_list:
            os.chdir(path + directory)
            dir_dir:list[str] = os.listdir(path + directory)
            for dir in dir_dir:
                if os.path.isdir(dir):
                    os.chdir(path + directory + '/'+dir)
                    dir_dir_dir:list[str] = os.listdir(path + directory + '/'+dir)
                    for file in dir_dir_dir:
                        if file == 'src':
                            os.chdir(path + directory + '/'+dir + '/'+file)
                            current_file:list[str] = os.listdir(path + directory + '/'+dir + '/'+file)
                            file_list.append(path + directory + '/'+ dir +'/'+file + f'/{current_file[0]}')
                            os.chdir('..')
                    os.chdir('..')
            os.chdir('..')
    os.chdir(original_path)
    return file_list


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


def readfile(file:str) -> list[str]:

    with open(file,'r') as fr:
            line:str = fr.read()
            
            line = re.sub(r'//.*', '', line)
            line = re.sub(r'/\*(.|\n)*?\*/', '', line)
            line = re.sub(r'#.*', '', line)
            line = re.sub(r'(""").*?\1', '', line,flags=re.DOTALL)
            line = re.sub(r'\n{2,}', '\n', line)
            line = line.strip()
            line = re.sub(r'[\t ]','', line, flags=re.MULTILINE)
    
    #print(line)
    words:list[str] = [word for word in line.split() if word != '']
    return words



def similars() -> None:
    paths:list[str] = getpath()
    resultsfile=open('copycheck.txt','wt')
    resultsfile.write('1.0: Taydellinen samankaltaisuus\n'
            '0.9 - 0.99: Erittain korkea samankaltaisuus\n'
            '0.8 - 0.89: Korkea samankaltaisuus\n'
            '0.7 - 0.79: Hyva samankaltaisuus\n'
            '0.6 - 0.69: Kohtalainen samankaltaisuus\n'
            '0.5 - 0.59: Vahainen samankaltaisuus\n'
            '0.0 - 0.49: Vahan tai ei lainkaan samankaltaisuutta\n\n')
    
    for i in range(len(paths) - 1):
        first_file:list[str] = readfile(paths[i])
        sim:int=0
        for j in range(1, len(paths) - i):
            sim = 0
            second_file:list[str] = readfile(paths[j+i])
            for line in first_file:
                for word in second_file:
                    if line == word:
                        sim = sim + 1

            first_path_rep = paths[i].replace('/',' ').replace('\\', ' ')
            first_path_list:list[str] = first_path_rep.split()

            path_rep = paths[j+i].replace('/',' ').replace('\\', ' ')

            path_list:list[str] = path_rep.split()

            vec1 = Counter(first_file)
            vec2 = Counter(second_file)

            intersection = set(vec1.keys()) & set(vec2.keys())
            numerator = sum([vec1[x] * vec2[x] for x in intersection])

            sum1 = sum([vec1[x]**2 for x in vec1.keys()])
            sum2 = sum([vec2[x]**2 for x in vec2.keys()])

            denominator = math.sqrt(sum1) * math.sqrt(sum2)

            #resultsfile.write(f'{path_list[10]}\n')
            resultsfile.write(f'Tiedoston {first_path_list[10]} ja tiedoston {path_list[10]} samankaltaisuus: {(float(numerator) / denominator):.5f}% \n')

    resultsfile.close()



def main() -> None:
    similars()
 

if __name__ == '__main__':
    main()