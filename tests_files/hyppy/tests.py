import sys
import unittest
import os
helpers_path = os.path.abspath(os.path.join(os.path.dirname(__file__), '../../../../helpers'))
sys.path.append(helpers_path)
modul_path = os.path.abspath(os.path.join(os.path.dirname(__file__), '../../../../modules'))
sys.path.append(modul_path)

from helpers import callDotNetFunction, loadmycode
from cleancode import clean


started_tests = 0
completed_tests = 0


class TestCode(unittest.TestCase):
    
    def test1(self):
        #Test C# program
        self.startTest()
        output:str=''
        srcpath:str = 'src'
        for file in os.listdir(srcpath):
            mycode:str=loadmycode('src'+'/'+file)

        line = clean(mycode)
        output=callDotNetFunction(cmdline_args=[], input='89\n17\n15\n16,5\n20\n18,5\n', timeout=15, build=True)
        expected_output:list[str] = ['const','90','KysyHypynPituus','KysyTuomareidenPisteet','LaskeHypynPisteet','Tulosta']
        for ec in expected_output:
            self.assertIn(ec, line, f'Expected output not found: {ec}')
        
        notexpected_result:list[str] = ['return']
        for ner in notexpected_result:
            self.assertNotIn(ner, line, f'Not expected output found: {ner}')
        
        print(f'Output: {output}')
        expected_result = ['110,2','89']
        for er in expected_result:
            self.assertIn(er, output, f'Output is not correct: {er}')
        
        self.endTest()

    def test2_negatives(self):
        #Test C# program with negative numbers
        self.startTest()
        output:str=''
        output=callDotNetFunction(cmdline_args=[], input='89\n-17\n17\n-15\n15\n-16,5\n16,5\n-20\n20\n-18,5\n18,5\n', timeout=15, build=False)
        print(f'Output: {output}')
        expected_result = ['110,2','89']
        for er in expected_result:
            self.assertIn(er, output, f'Output is not correct: {er}')
        
        self.endTest()

    def test3_bigger_than_20(self):
        #Test C# program with bigger than 20
        self.startTest()
        output:str=''
        output=callDotNetFunction(cmdline_args=[], input='89\n27\n17\n45\n15\n35\n16,5\n87\n20\n76\n18,5\n', timeout=15, build=False)
        print(f'Output: {output}')
        expected_result = ['110,2','89']
        for er in expected_result:
            self.assertIn(er, output, f'Output is not correct: {er}')
        
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