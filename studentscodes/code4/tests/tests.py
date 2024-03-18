
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


