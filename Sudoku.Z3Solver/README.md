# R�solveur de Sudoku utilisant la librairie Z3

## Authors

- Adrien GIGET
- Ethan MACHAVOINE
- Jonathan POELGER

## Introduction

Ce projet pr�sente diff�rentes impl�mentations d'un solveur de Sudoku en utilisant 
la biblioth�que de SMT solver Z3 de Microsoft. Nous avons discut� et impl�ment� 
plusieurs approches pour r�soudre des grilles de Sudoku en utilisant Z3, 
notamment les impl�mentations suivantes :

* Z3Int
* Z3BitVector

Chaque impl�mentation utilise des techniques diff�rentes pour d�finir et r�soudre
les contraintes de Sudoku.

## Approches

### Z3Int

Cette approche utilise les entiers Z3 pour repr�senter les variables des cellules 
du Sudoku. Les contraintes g�n�riques et les contraintes sp�cifiques � la grille 
sont d�finies en utilisant les expressions bool�ennes et les expressions 
arithm�tiques de Z3. Cette m�thode est assez simple et directe, mais elle peut ne 
pas �tre aussi efficace que d'autres approches en termes de performances et 
d'utilisation des ressources.

### Z3BitVector

Cette approche utilise les BitVecs pour repr�senter les variables des cellules du 
Sudoku. Les contraintes g�n�riques et les contraintes sp�cifiques � la grille sont
d�finies en utilisant les expressions bool�ennes de Z3. Mais �tant cod� sur 4 bits, 
suffisant pour exprimer les chiffres de 0 � 9 d'un soduku, cela permet d'acc�l�rer 
le traitement.

## D�clinaison avec les propri�t�es de Z3

* ReusableScope
* ReusableHypothesis
* Substitution
* Tactics

### ReusableScope

Cette approche utilise un contexte r�utilisable avec la m�thode Push() et Pop()
pour g�rer efficacement les contraintes lors de la r�solution du Sudoku. Cela permet
de mieux g�rer les ressources et d'am�liorer les performances en ne recalculant
pas les contraintes � chaque it�ration.

### ReusableHypothesis

Dans cette approche, on cr�e une hypoth�se r�utilisable pour les contraintes de
base du Sudoku, ce qui permet de r�duire les calculs redondants et d'am�liorer
les performances. Les contraintes sp�cifiques � la grille sont ajout�es au fur
et � mesure, et l'hypoth�se est utilis�e pour v�rifier la validit� de la grille.

### Substitution

Cette m�thode exploite la substitution pour remplacer les variables par les 
valeurs r�elles du Sudoku, r�duisant ainsi la complexit� des contraintes et 
am�liorant les performances du solveur.

### Tactics

L'approche des tactiques permet d'utiliser les tactiques Z3 pour guider la 
r�solution du probl�me du Sudoku. Les tactiques sont des heuristiques qui 
peuvent �tre appliqu�es pour simplifier et r�soudre les probl�mes logiques. 
En combinant plusieurs tactiques, cette m�thode peut offrir une r�solution 
plus rapide et efficace du Sudoku.


## Tests de performance

Les performances de chaque impl�mentation ont �t� test�es sur plusieurs 
grilles de Sudoku de niveaux de difficult� "Medium". Les temps d'ex�cution
et l'utilisation des ressources ont �t� compar�s pour chaque impl�mentation.

* Z3Int
    * Base : 2 811 ms
    * ReusableScope : 6 467 ms
    * ReusableHypothesis : 6 148 ms
    * Substitution : 2 481 ms

* Z3BitVector
    * Base : 622 ms
    * ReusableScope : 1 463 ms
    * ReusableHypothesis : 1 167 ms
    * Substitution : 513 ms
    * ReusableScope + Tactic : 1 118 ms
    * Substitution + Tactic : 504 ms


Les temps d'ex�cution peuvent varier en fonction de la machine et des 
grilles test�es.


## Conclusion

En conclusion, ce projet montre comment utiliser la biblioth�que Z3 pour 
r�soudre des grilles de Sudoku en utilisant diff�rentes approches. Les 
impl�mentations pr�sent�es offrent des performances variables en fonction 
des tactiques et des optimisations utilis�es. Les tests de performance 
montrent que l'utilisation d'une port�e r�utilisable et de tactiques Z3 
peut avoir un impact sur les performances et l'utilisation des ressources 
pour r�soudre des grilles de Sudoku.