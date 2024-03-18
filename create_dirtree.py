import os
import shutil
import subprocess
testall = """
import os
import sys
import subprocess

if __name__=='__main__':
    resultsfile=open('results.txt', 'wt')
    skiplist=['ex_template', 'helpers']

    for file in os.listdir('.'):
        if file in skiplist:
            continue
        if os.path.isdir(file):
            cmdline=sys.executable+' test.py'
            print(cmdline)
            #rc=os.system(cmdline)
            #print('#', rc)
            rc=subprocess.call(cmdline, shell=True, cwd=file)
            #print('#', rc)
            try:
                exresfile=open(file+'/tests/result.txt', 'rt')
                res=exresfile.read()
                #print('#',res)
                resultsfile.write(file+'\t'+res+'\n')
                exresfile.close()
            except:
                #Result file not found
                resultsfile.write(file+'\t'+'0\t0\n')
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
    sys.path.insert(0, path+'../helpers')

    #Import code to test
    from tests import *

    curr_file=os.path.abspath(__file__)
    exname = split(curr_file)[-2]

    print('Test', exname)

    #if __name__ == '__main__':
    unittest.main(verbosity=2, exit=False)

    outputfile=open(resultfile, 'wt')
    outputfile.write('{0}\t{1}'.format(completed(), started()))
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


started_tests = 0
completed_tests = 0


def rmoutput():
    for filename in []:
        try:
            os.remove(filename)
        except:
            pass


def repeat(times:int=0):
    def repeatHelper(f):
        def callHelper(*args) -> None:
            for i in range(0, times):
                f(*args)

        return callHelper

    return repeatHelper

class TestCode(unittest.TestCase):
    #@timeout_decorator.timeout(30)
    previous:str = ''
    extra_numbers:list[int] = []
    smallest = 0
    largest = 0
    occurences = {}
    @repeat(500)
    def test_VS(self):
        #Test C# program
        self.startTest()

        expected_output=['+']
        pattern = re.compile(r'^\s*(\d+\s+){6}\d+\s+\+\s+\d+\s+$')
        if started_tests > 1:
            output=callDotNet(cmdline_args=[], input='', timeout=15, build=False)
        else:
            output=callDotNet(cmdline_args=[], input='', timeout=15, build=True)

        for eo in expected_output:
            print('Check if "'+eo+'" is in output')
            self.assertIn(eo, output)

        self.assertRegex(output, pattern)
        numbers = [int(num) for num in output.split() if num.isdigit()]
        print('Output:', output)
        print('Previous:', self.previous)
        self.assertNotEqual(self.previous, output, msg='Output is the same as previous')

        for i in range(len(numbers) -1):
            current = numbers[i]
            next = numbers[i+1]
            print('Current:', current, 'Next:', numbers[i+1])
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
            least_common_num,least_common_count = min(self.occurences.items(), key=lambda x: x[1])
            most_common_num,most_common_count = max(self.occurences.items(), key=lambda x: x[1])

            #ordered_occurences = OrderedDict(sorted(self.occurences.items(), key=lambda x: x[1]))
            #print('Ordered:', ordered_occurences)
            threshold = 0.8 * most_common_count
        
            if least_common_count >= threshold:
                print('Least common number count is more than 80% of most common number count:')
                print(f'Least common number is {least_common_num} and occurs {least_common_count} times')
                print(f'Most common number is {most_common_num} and occurs {most_common_count} times')
                print(f'80% Most common number is: {threshold:.2f}')
            else:
                print('Least common number count is less than 80% of most common number count:')
                print(f'Least common number is {least_common_num} and occurs {least_common_count} times')
                print(f'Most common number is {most_common_num} and occurs {most_common_count} times')
                print(f'80% Most common number is: {threshold:.2f}')

        self.endTest()


    def startTest(self):
        global started_tests
        started_tests=started_tests+1
        print('Start test', started_tests)
        rmoutput()

    def endTest(self):
        global completed_tests
        print('End test', started_tests)
        completed_tests=completed_tests+1
        rmoutput()


def completed():
    global completed_tests
    return completed_tests

def started():
    global started_tests
    return started_tests


"""
skiplist = ['.git','helpers','dotnet_test','__pycache__','studentscodes','.gitignore','LICENSE','README.md','thesisAIdata.sln']
def create_dirtree() -> None:
    path = os.getcwd()
    
    for file in os.listdir(path):
        if file in skiplist:
            continue
        if os.path.isdir(file):
            print(f'{file} is a directory')
            # Create the src directory
            shutil.rmtree(file)
            os.mkdir(file)
            os.chdir(file)
            testall_file = open('testall.py','w')
            testall_file.write(testall)
            testall_file.close()
            for i in range(1,51):
                subprocess.run(['dotnet', 'new', 'console', '-n',f'0{i}','-o', f't{i}','--framework','net6.0'], check=True)
                #os.mkdir(f't{i}')
                os.chdir(f't{i}')
                print(os.getcwd())
                old_file = os.path.join(os.getcwd(), 'Program.cs')
                new_file = os.path.join(os.getcwd(), f't{i}.cs')
                os.rename(old_file, new_file)
                os.mkdir('src')
                shutil.move(new_file, 'src')
                #os.chdir('src')
                #file = open(f't{i}.cs', 'w')
                #file.close()
                #os.chdir('..')
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

            os.chdir('..')


def studenCodeTree() -> None:
    skiplist1 = ['.git','helpers','dotnet_test','__pycache__','tests','chatGPT','copilot','.gitignore','LICENSE','README.md','thesisAIdata.sln']
    path = os.getcwd()
    copypath = 'C:/Users/Markku/Desktop/Markku_Koulu/Opinnäytetyö/lotto/lotto'
    i:int = 1
    for file1 in os.listdir(path):
        if file1 in skiplist1:
             continue
        if os.path.isdir(file1):
            print(f'{file1} is a directory')
            #Create the src directory
            shutil.rmtree(file1)
            os.mkdir(file1)
            os.chdir(file1)
            testall_file = open('testall.py','w')
            testall_file.write(testall)
            testall_file.close()
            for file in os.listdir(copypath):
                print(file)
                subprocess.run(['dotnet', 'new', 'console', '-n',f'0{i}','-o', f'code{i}','--framework','net6.0'], check=True)
                os.chdir(f'code{i}')
                old_file = os.path.join(os.getcwd(), 'Program.cs')
                os.remove(old_file)
                #new_file = os.path.join(os.getcwd(), f'{file}')
                new_file= shutil.copy(copypath + f'/{file}', os.getcwd() + f'/{file}')
                #os.rename(old_file, new_file)
                os.mkdir('src')
                shutil.move(new_file, 'src')
                #os.chdir('src')
                #file = open(f't{i}.cs', 'w')
                #file.close()
                #os.chdir('..')
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
    #create_dirtree()
    #studenCodeTree()