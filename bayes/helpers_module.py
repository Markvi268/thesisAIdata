import os
import re


def getpaths(current_dir:str) -> list[str]:
    """
    This function retrieves a list of file paths for the first file in the 'src' directory of each subdirectory 
    within the specified directory.

    The function specifically looks for a directory named as the 'current_dir' parameter in the parent directory. 
    Within this directory, it navigates into any subdirectories it finds. If a subdirectory named 'src' is found, 
    the function collects the path of the first file in this 'src' directory.

    Parameters
    ----------
    current_dir : str
        The name of the directory to be searched.

    Returns
    -------
    list[str]
        A list of file paths collected from 'src' directories within the specified directory.
    """
    original_path:str = os.path.dirname(__file__)
    file_list:list[str] = []

    for directory in os.listdir('../'):
        if directory == current_dir:
            os.chdir('../' + directory)
            for dir in os.listdir('.'):
                if os.path.isdir(dir):
                    os.chdir(dir)
                    for file in os.listdir('.'):
                        if os.path.isdir(file):
                            os.chdir(file)
                            for f in os.listdir('.'):
                                if f == 'src':
                                    os.chdir(f)
                                    current_file:list[str] = os.listdir('.')
                                    file_list.append(os.getcwd() + f'/{current_file[0]}')
                                    os.chdir('..')
                            os.chdir('..')
                    os.chdir('..')

    os.chdir(original_path)
    return file_list

def read_and_clean_file(file:str) -> list[str]:
    """
    This function reads a file and performs several regular expression substitutions on its content.

    The function performs the following operations:
    - Removes block comments (/*...*/)
    - Removes single-line comments starting with // at the beginning of a line or in the middle
    - Replaces multiple consecutive newline characters with a single newline
    - Removes leading and trailing whitespaces
    - Replaces multiple consecutive spaces with a single space
    - Removes curly braces ({ and })
    - Removes lines containing the word 'class'
    - Removes lines containing the phrase 'static void Main'
    - Removes the Unicode character '\ufeff'

    Parameters
    ----------
    file : str
        The path to the file to be read.

    Returns
    -------
    list[str]
        The content of the file as a list of strings, with certain patterns removed.
    """

    cleaned_file:list[str] = []
    with open(file, 'r',encoding='utf-8') as fr:
            line:str = fr.read()

            line = re.sub(r'/\*(.|\n)*?\*/', '', line)
            line = re.sub(r'//.*$', '', line, flags=re.MULTILINE)
            line = re.sub(r'^//.*$', '', line, flags=re.MULTILINE)
            line = re.sub(r'\n{2,}', '\n', line, flags=re.MULTILINE)
            line = line.strip()
            line = re.sub(r'^[ \t]+','', line, flags=re.MULTILINE)
            line = re.sub(r' {2,}', ' ', line, flags=re.MULTILINE)
            line = re.sub(r'[{}]', '', line, flags=re.MULTILINE)
            line = re.sub(r'^.*\bclass\b.*$', '', line, flags=re.MULTILINE)
            line = re.sub(r'^.*\bstatic void Main\b.*$', '', line, flags=re.MULTILINE)
            line = line.replace('\ufeff','')

    splitted_line = "\n".join([l for l in line.split("\n") if l.strip()])

    cleaned_file = splitted_line.split('\n')
    return cleaned_file


def get_test_files(test_files:list[str]) -> list[str]:
    """
    This function retrieves a list of file paths for all '.cs' files in the directories specified in the 'test_files' parameter.

    The function specifically looks for directories named as per the 'test_files' parameter in the parent directory. 
    Within these directories, it collects the path of all '.cs' files.

    Parameters
    ----------
    test_files : list[str]
        The names of the directories to be searched.

    Returns
    -------
    list[str]
        A list of file paths collected from the directories specified in the 'test_files' parameter.
    """
    original_path:str = os.path.dirname(__file__)
    file_list:list[str] = []
    for file in os.listdir('../'):
        if file in test_files:
            os.chdir('../' + file)
            for i in os.listdir('.'):
                if i.endswith('.cs'):
                    file_list.append(os.getcwd() + f'/{i}')
    os.chdir(original_path)
    return file_list