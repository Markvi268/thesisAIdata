import os
import re


def get_file_path() -> list[str]:
    original_path:str = os.path.dirname(__file__)
    parent_path:str = os.path.dirname(original_path)

    current_dir:str = parent_path + '/lotto_train_data'
    file_list:list[str] = []
    dir_list:list[str] = ['chatgpt_train_data','copilot_train_data','students_train_data']
    for dir in os.listdir(current_dir):
        if dir in dir_list:
            for file in os.listdir(current_dir+'/'+dir):
                if os.path.isdir(current_dir+'/'+dir+'/'+file):
                    for f in os.listdir(current_dir+'/'+dir+'/'+file):
                        if f == 'src':
                            for f1 in os.listdir(current_dir+'/'+dir+'/'+file+'/'+f):
                                file_list.append(current_dir+'/'+dir+'/'+file+'/'+f+'/'+f1)

    return file_list           
                    
def readfile() -> tuple[dict[str,int], dict[str,int]]:
    paths:list[str] = get_file_path()
    occurences_ai:dict[str, int] = {}
    occurences_students:dict[str, int] = {}

    for path in paths:
        with open(path,'r') as fr:
            line:str = fr.read()
            tulos = re.search(r'\bint\[\]\s+(\w+)\s*=', line)
            tulos1 = re.search(r'\bint\[\,]\s+(\w+)\s*=', line)
            if 'chatgpt' in path or 'copilot' in path:
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

            if 'students' in path:
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

    return (occurences_ai, occurences_students)




def writeCode() -> None:
    occurences_ai, occurences_students = readfile()

    
    with open ('arraynames.txt','w') as f:
        f.write('AI code:\n')
        for key, value in occurences_ai.items():
            f.write(f'{key}: {value}\n')
        f.write('-'*20+'\n')
        f.write(f'Total: {sum(occurences_ai.values())}\n')
        f.write('\n')
        f.write('Students code:\n')
        for key, value in occurences_students.items():
            f.write(f'{key}: {value}\n')
        f.write('-'*20+'\n')
        f.write(f'Total: {sum(occurences_students.values())}\n')
        f.write('\n')
        f.write('Differences:\n')
        for key, value in occurences_students.items():
                if key not in occurences_ai:
                    f.write(f'{key}: Students {value} AI: 0\n')
                else:
                    f.write(f'{key}: Students: {value} AI: {occurences_ai[key]}\n')

            


if __name__ == '__main__':
    writeCode()