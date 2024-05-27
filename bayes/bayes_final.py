from sklearn.naive_bayes import MultinomialNB
from sklearn.metrics import accuracy_score
from sklearn.model_selection import train_test_split, GridSearchCV
from sklearn.feature_extraction.text import CountVectorizer
import time

import helpers_module as hm

def bayes(features:list[str], label:list[int],test_files:list[str]) -> None:
    """
    This function performs a Naive Bayes classification on the given features and labels.

    The function first vectorizes the features using CountVectorizer. It then splits the data into training and test sets. 
    A grid search is performed to find the best 'alpha' parameter for the Multinomial Naive Bayes classifier.

    Parameters
    ----------
    features : list[str]
        The features to be used for training the classifier. Each element in the list is a string representing a feature.

    label : list[int]
        The labels corresponding to the features. Each element in the list is an integer representing a label.

    test_files : list[str]
        The names of the directories to be searched for test files.

    Returns
    -------
    None

    Prints
    ------
    The function prints the following:
    - Start of the training process
    - Best hyperparameters found by the grid search
    - Best score achieved by the grid search
    - Accuracy of the best model on the test data
    - Completion of the training process
    """

    print('Start bayes training...')

    vectorized = CountVectorizer()
    X = vectorized.fit_transform(features)
    X_train, X_test, y_train, y_test = train_test_split(X, label, test_size=0.2,random_state=40)

    params:dict[str,list[float]] = {'alpha': [0.01, 0.02, 0.03, 0.04, 0.05, 0.06, 0.07, 0.08, 0.09, 0.1, 0.2, 0.3, 0.5, 0.6, 0.7, 0.8, 0.9, 1.0, 1.5, 2.0, 3.0]}
    
    K_fold:int = 4
    model = MultinomialNB()
    classifier = GridSearchCV(estimator=model, param_grid=params, cv=K_fold)
    classifier.fit(X_train, y_train)

    best_param = classifier.best_params_
    best_model = MultinomialNB(alpha=best_param['alpha'],fit_prior=True)
    print(f'Best hyperparameter: {best_param}')
    print(f'Best score: {classifier.best_score_:.4f}')

    best_model.fit(X_train, y_train)
    y_pred = best_model.predict(X_test)
    print(f'Test data accuracy: {accuracy_score(y_test, y_pred):.4f}')
    print('Training completed...')
    print()

    print('Testing new .cs file..')
    time.sleep(2)
    testfiles:list[str] = hm.get_test_files(test_files)
    result_list:list[str] = []
    i:int = 1
    for file in testfiles:
        new_file = hm.read_and_clean_file(file=file)
        X_test_data = vectorized.transform(new_file)
        prediction = best_model.predict(X_test_data)

        human_count = sum(1 for preds in prediction if preds == 0)
        ai_count = sum(1 for preds in prediction if preds == 1)
        total:int = human_count + ai_count
        pros:float = (human_count/total)*100
        f = file.split('/')[1]
        result_list.append(f't{i} is {100-pros:.2f} % AI code')
        i = i + 1

    print('Testing completed...\n')
    writefile(result_list)


def writefile(res_list:list[str]) -> None:
    """
    This function writes the results of the Naive Bayes classification to a file.

    Parameters
    ----------
    res_list : list[str]
        The list of results to be written to the file. Each element in the list is a string representing a result.

    Returns
    -------
    None
    """
    print('Writing results to file...')
    with open('bayes_result.txt', 'w') as f:
        f.write('Bayes results!\n\n')
        for res in res_list:
            f.write(res + '\n')
        f.write('\n0% MEANS THAT THE CODE IS 100% HUMAN GENERATED')

    print('Results written to file...')

def main() -> None:
    """
    This function is the main entry point of the program.

    It first retrieves a list of file paths using the `getpaths` function from different directories

    It then reads each file in the list, categorizing the words into two categories: 'humanwords' and 'aiwords', 
    based on whether 'chatgpt' or 'copilot' is in the file path. 

    The function then prints the length of 'humanwords' and 'aiwords'. 

    Finally, it combines 'humanwords' and 'aiwords' into a single list 'allcode', creates a corresponding list of labels, 
    and passes these to the `bayes` function for Naive Bayes classification.

    Returns
    -------
    None
    """
    # Insert to list test data directories
    test_file_dirs:list[str] = []

    # train data directories
    filepath_list:list[str] = []
    filepath_list += hm.getpaths('')
    filepath_list += hm.getpaths('')
    filepath_list += hm.getpaths('')        
    humanwords:list[str] = []
    aiwords:list[str] = []
    for file_path in filepath_list:
        if 'chatgpt' in file_path or 'copilot' in file_path:
            aiwords += hm.read_and_clean_file(file_path)
        else:
            humanwords += hm.read_and_clean_file(file_path)
            
    print(f'Words len: Human: {len(humanwords)} AI: {len(aiwords)}')

    labels:list[int] = [0]*len(humanwords) + [1]*len(aiwords)
    allcode:list[str] = humanwords + aiwords

    bayes(allcode, labels,test_file_dirs)

if __name__ == '__main__':
    main()