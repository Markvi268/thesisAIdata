import os
import shutil
import subprocess
import time

def create_ai_train_data_tree() -> None:
    original_path:str = os.path.dirname(__file__)
    parent_path:str = os.path.dirname(original_path)
    copytestspath = parent_path + '/hyppy_tests_files'
    dir_list:list[str] = ['chatgpt_train_data','copilot_train_data']
    current_dir:str = 'hyppy_train_data'
    for directory in os.listdir('../'):
        if directory == current_dir:
            os.chdir('../'+directory)
            for dir in os.listdir('.'):
                if dir in dir_list:
                    if os.path.exists(dir):
                            print(f'Remove old {dir} directory...')
                            shutil.rmtree(dir)
                            time.sleep(1)
                            print(f'Create new {dir} directory...')
                            os.mkdir(dir)
                            time.sleep(1)
                    os.chdir(dir)
                    shutil.copy(copytestspath + '/testall.py', os.getcwd() + '/testall.py')
                    for i in range(1,11):
                        cmd_line = ['dotnet', 'new', 'console', '-n',f'AI0{i}','-o', f'AItest0{i}','--framework','net6.0']
                        if i >= 10:
                            cmd_line[4] = f'AI{i}'
                            cmd_line[6] = f'AItest{i}'

                        subprocess.run(cmd_line, check=True)
                        os.chdir(cmd_line[6])
                        old_file = os.path.join(os.getcwd(), 'Program.cs')
                        new_file = os.path.join(os.getcwd(), f'testcode{i}.cs')
                        os.rename(old_file, new_file)
                        os.mkdir('src')
                        shutil.move(new_file, 'src')
                        os.mkdir('tests')
                        shutil.copy(copytestspath + '/test.py', os.getcwd() + '/test.py')
                        shutil.copy(copytestspath + '/tests.py', os.getcwd() + '/tests/tests.py')

                        os.chdir('..')

                    os.chdir('..')
                    

            
def create_student_train_data_tree() -> None:
    original_path:str = os.path.dirname(__file__)
    parent_path:str = os.path.dirname(original_path)
    dir_list:list[str] = ['hyppy_train_data']
    current_dir:str = 'students_train_data'
    copypath =parent_path + '/makihyppy'
    copytestspath = parent_path + '/hyppy_tests_files'
    i:int = 1
    for directory in os.listdir('../'):
        if directory in dir_list:
            if os.path.isdir('../'+ directory):
                os.chdir('../'+ directory)
                for dir in os.listdir('.'):
                    if dir == current_dir:
                        if os.path.exists(dir):
                            print(f'Remove old {dir} directory...')
                            shutil.rmtree(dir)
                            time.sleep(1)
                            print(f'Create new {dir} directory...')
                            os.mkdir(dir)
                            time.sleep(1)
                            os.chdir(dir)

                            shutil.copy(copytestspath + '/testall.py', os.getcwd() + '/testall.py')
                            for file in os.listdir(copypath):
                                cmd_line = ['dotnet', 'new', 'console', '-n',f'0{i}','-o', f'code0{i}','--framework','net6.0']
                                if i >= 10:
                                    cmd_line[4] = f'{i}'
                                    cmd_line[6] = f'code{i}'
                                subprocess.run(cmd_line, check=True)
                                os.chdir(cmd_line[6])
                                old_file = os.path.join(os.getcwd(), 'Program.cs')
                                os.remove(old_file)
                                os.mkdir('src')
                                shutil.copy(copypath + f'/{file}', os.getcwd() + f'/src/{file}')
                                os.mkdir('tests')
                                shutil.copy(copytestspath + '/tests.py', os.getcwd() + '/tests/tests.py')
                                shutil.copy(copytestspath + '/test.py', os.getcwd() + '/test.py')
                                os.chdir('..')
                                i+=1
    os.chdir(original_path)
                            
                        
if __name__ == '__main__':
    #create_ai_train_data_tree()
    #create_student_train_data_tree()