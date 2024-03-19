import os
import shutil
import subprocess
import time
testall = """
import os
import sys
import subprocess

if __name__=='__main__':

    resultsfile=open('results.txt', 'wt')

    for directory in os.listdir('.'):
        if os.path.isdir(directory):
            cmdline=sys.executable+' test.py'
            rc=subprocess.run(cmdline, cwd=directory)
            try:
                exresfile=open(directory+'/tests/result.txt', 'rt')
                res=exresfile.read()
                exresfile.close()
                resultsfile.write(directory+'\t'+res+'\n')
            except:
                #Result file not found
                resultsfile.write(directory+'\t'+'0\t0\n')
                pass

    resultsfile.close()

"""
test = """
import sys
import unittest
import os
import re

if __name__=='__main__':

    def split(s:str) -> list[str]:
        return re.split('/|////', s)

    #Find path to current root
    pathlist=split(sys.argv[0])
    if len(pathlist)==1:
        path='./'
    else:
        path=pathlist[0]+'/'
    testpath=path+'tests'

    resultfile=testpath+'/result.txt'
    try:
        os.remove(resultfile)
    except:
        pass

    sys.path.insert(0, testpath)
    sys.path.insert(0, path+'src')

    from tests import *

    curr_file=os.path.abspath(__file__)
    exname = split(curr_file)[-2]

    print('Test', exname)

    unittest.main(verbosity=2, exit=False)

    outputfile=open(resultfile, 'wt')
    outputfile.write('{0}   {1}'.format(completed(), started()))
    outputfile.close()
    if started()>completed():
        print(started()-completed(), '/', started(), 'tests failed!')
    else:
        print(completed(),'tests completed succesfully')


"""

tests = """
import sys
import unittest
import os
import re
src_path = os.path.abspath(os.path.join(os.path.dirname(__file__), '../../../helpers'))
sys.path.append(src_path)
from helpers import *
from functools import partial

started_tests = 0
completed_tests = 0

def repeat(times:int=0):
    def repeatHelper(f):
        def callHelper(*args:None) -> None:
            part_func = partial(f, *args)
            for _ in range(times):
                part_func()

        return callHelper

    return repeatHelper

class TestCode(unittest.TestCase):
    
    previous:str = ''
    extra_numbers:list[int] = []
    smallest:int = 0
    largest:int = 0
    occurences:dict[int,int] = {}

    @repeat(times=500)
    def test_VS(self):
        #Test C# program
        self.startTest()
        output:str=''
        pattern = re.compile(r'^(\d+\s+){7}\+\s+\d+\s*$')
        if started_tests > 1:
            output=callDotNet(cmdline_args=[], input='', timeout=15, build=False)
        else:
            output=callDotNet(cmdline_args=[], input='', timeout=15, build=True)

        self.assertRegex(output, pattern)

        numbers = [int(num) for num in output.split() if num.isdigit()]

        self.assertNotEqual(self.previous, output, msg='Output is the same as previous')

        for i in range(len(numbers) -1):
            current = numbers[i]
            next = numbers[i+1]
            self.assertGreater(current,0, msg='Number is not greater than 1')
            self.assertGreater(next,0, msg='Number is not greater than 1')
            self.assertGreater(41,current,msg='Number is greater than 41')
            self.assertGreater(41,next, msg='Number is greater than 41')
            if i == 6:
                self.extra_numbers.append(next)
                break
            self.assertGreater(next, current)
            
        for num in numbers:
            if num in self.occurences:
                self.occurences[num] += 1
            else:
                self.occurences[num] = 1
        
        self.previous = output
        if started_tests == 500:
            self.largest = max(self.extra_numbers)
            self.smallest = min(self.extra_numbers)
            self.assertEqual(1, self.smallest, msg='Smallest number is not 1')
            self.assertEqual(40, self.largest, msg='Largest number is not 40')
            print('Largest:', self.largest)
            print('Smallest:', self.smallest)
            least_common_count = min(self.occurences.items(), key=lambda x: x[1])
            most_common_count = max(self.occurences.items(), key=lambda x: x[1])

            threshold = 0.6 * most_common_count[1]

            self.assertGreater(least_common_count[1], threshold, msg='Least common number count is less than 60% of most common number count')


        self.endTest()


    def startTest(self):
        global started_tests
        started_tests=started_tests+1
        print('Start test', started_tests)

    def endTest(self):
        global completed_tests
        print('End test', started_tests)
        completed_tests=completed_tests+1
        print()


def completed():
    global completed_tests
    return completed_tests

def started():
    global started_tests
    return started_tests

"""
skiplist = ['.git','helpers','dotnet_test','__pycache__','studentscodes','.gitignore','LICENSE','README.md','thesisAIdata.sln','solution','create_dirtree.py']
def create_AIdirtree() -> None:
    
    for directory in os.listdir('.'):
        if directory in skiplist:
            continue
        if os.path.isdir(directory):
            print(f'Remove old {directory} directory...')
            shutil.rmtree(directory)
            time.sleep(1)
            print(f'Create new {directory} directory...')
            time.sleep(1)
            os.mkdir(directory)
            os.chdir(directory)

            # Create testall.py file
            testall_file = open('testall.py','w')
            testall_file.write(testall)
            testall_file.close()

            for i in range(1,51):
                subprocess.run(['dotnet', 'new', 'console', '-n',f'AI0{i}','-o', f'AItest{i}','--framework','net6.0'], check=True)
                os.chdir(f'AItest{i}')
                print(os.getcwd())
                old_file = os.path.join(os.getcwd(), 'Program.cs')
                new_file = os.path.join(os.getcwd(), f'testcode{i}.cs')
                os.rename(old_file, new_file)
                os.mkdir('src')
                shutil.move(new_file, 'src')
                os.mkdir('tests')
                os.chdir('tests')

                tests_file = open('tests.py', 'w')
                tests_file.write(tests)
                tests_file.close()
                os.chdir('..')

                test_file = open('test.py', 'w')
                test_file.write(test)
                test_file.close()
                os.chdir('..')

            os.chdir('..')


def studenCodeTree() -> None:
    skiplist1 = ['.git','helpers','dotnet_test','__pycache__','tests','chatGPT','copilot','.gitignore','LICENSE','README.md','thesisAIdata.sln','solution']

    copypath = 'C:/Users/Markku/Desktop/Markku_Koulu/Opinnäytetyö/lotto/lotto'
    i:int = 1
    for directory in os.listdir('.'):
        if directory in skiplist1:
             continue
        if os.path.isdir(directory):
            print(f'Remove old {directory} directory...')
            shutil.rmtree(directory)
            time.sleep(1)
            print(f'Create new {directory} directory...')
            os.mkdir(directory)
            time.sleep(1)
            os.chdir(directory)

            # Create testall.py file
            testall_file = open('testall.py','w')
            testall_file.write(testall)
            testall_file.close()

            for file in os.listdir(copypath):
                subprocess.run(['dotnet', 'new', 'console', '-n',f'0{i}','-o', f'code{i}','--framework','net6.0'], check=True)
                os.chdir(f'code{i}')
                old_file = os.path.join(os.getcwd(), 'Program.cs')
                os.remove(old_file)
                os.mkdir('src')
                shutil.copy(copypath + f'/{file}', os.getcwd() + f'/src/{file}')
                os.mkdir('tests')
                os.chdir('tests')

                file = open('tests.py', 'w')
                file.write(tests)
                file.close()
                os.chdir('..')

                test_file = open('test.py', 'w')
                test_file.write(test)
                test_file.close()
                os.chdir('..')
                i+=1

                
if __name__ == '__main__':
    #create_AIdirtree()
    #studenCodeTree()