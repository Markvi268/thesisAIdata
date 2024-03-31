import os
import re


def readCode() -> tuple[dict[str, int], dict[str, int]]:
    #path:str = 'chatGPT/AItest01/src/testcode1.cs'
    occurences_ai:dict[str, int] = {}
    occurences_students:dict[str, int] = {}

    dir_list:list[str] = ['chatGPT','copilot','studentscodes']

    for directory in os.listdir('.'):
        if directory in dir_list:
            #print(f'Found directory: {directory}')
            os.chdir(directory)
            for file in os.listdir('.'):
               if os.path.isdir(file):
                 #print(f'Found directory in {directory}: {file}')
                 os.chdir(file)
                 for file in os.listdir('.'):
                     if os.path.isdir(file):
                         if file == 'src':
                             os.chdir(file)
                             for file in os.listdir('.'):
                                 if os.path.exists(os.getcwd()):
                                     with open (os.getcwd() + f'/{file}', 'r') as file:
                                         for line in file:
                                             tulos = re.search(r'\bint\[\]\s+(\w+)\s*=', line)
                                             tulos1 = re.search(r'\bint\[\,]\s+(\w+)\s*=', line)
                                             #print(line)
                                             if directory == 'chatGPT' or directory == 'copilot':
                                                if tulos:
                                                    if tulos.group(1) in occurences_ai:
                                                        occurences_ai[tulos.group(1)] += 1
                                                    else:
                                                        occurences_ai[tulos.group(1)] = 1
                                                if tulos1:
                                                    if tulos1.group(1) in occurences_ai:
                                                        occurences_ai[tulos1.group(1)] += 1
                                                    else:
                                                        occurences_ai[tulos1.group(1)] = 1

                                             if directory == 'studentscodes':
                                                if tulos:
                                                    if tulos.group(1) in occurences_students:
                                                        occurences_students[tulos.group(1)] += 1
                                                    else:
                                                        occurences_students[tulos.group(1)] = 1
                                                if tulos1:
                                                    if tulos1.group(1) in occurences_students:
                                                        occurences_students[tulos1.group(1)] += 1
                                                    else:
                                                        occurences_students[tulos1.group(1)] = 1
                                                 
                                                 
                                 os.chdir('..')
                             os.chdir('..')
            os.chdir('..')
    return (occurences_ai, occurences_students)            
                    
                       
def writeCode() -> None:
    occurences_ai, occurences_students = readCode()
    
    with open ('results.txt','w') as f:
        f.write('AI code:\n')
        for key, value in occurences_ai.items():
            f.write(f'{key}: {value}\n')
        f.write('\n')
        f.write('Students code:\n')
        for key, value in occurences_students.items():
            f.write(f'{key}: {value}\n')
        f.write('\n')
        f.write('Differences:\n')
        for key, value in occurences_students.items():
                if key not in occurences_ai:
                    f.write(f'{key}: Students {value} AI: 0\n')
                else:
                    f.write(f'{key}: Students: {value} AI: {occurences_ai[key]}\n')

            


if __name__ == '__main__':
    writeCode()