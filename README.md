# ML-Unity


## ML Project Notes


- install python version 3.7 (issues are likely even with the latest py version, just use unity recommenation)
- create a py virtural environment
``python -m venv {foldername}``


- update packages 
``python -m pip install --upgrade pip``
- install PyTorch, mlagents 

pytorch unity recommends: ``pip install torch~=1.7.1 -f https://download.pytorch.org/whl/torch_stable.html``
mlagents: ``python -m pip install mlagents==0.30.0 OR python -m pip install mlagents <----- use this``

- run: ``mlagents-learn --help``
install any missing libraries, could be gpu speific 


(Issue) AttributeError: 'str' object has no attribute '_key' #5794
to solve: ``pip install importlib-metadata==4.4``


- Run test using mlagents-learn
	- to start a new model, use ``--force`` to overwrite the previous or ``--run-id={Name}``



