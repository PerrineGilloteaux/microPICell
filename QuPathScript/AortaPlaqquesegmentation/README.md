pour Qupath V0.1.2

Quantification des aortes entières :
1)	Prepare the list of images
   a.	Import Images
2)	Launch the detection of Aorta
   a.	Automate> Show script editor
   b.	In Script Editor windows, File> Open >AortaSelection.groovy
   c.	Run> Run for project, add the list of image if needed in the right column.
   d.	Correct manually if needed : In pannel annotation, click on the Polygon, right click on the image, annotation-> Unlock ; Alt + drawing to erase a part.
3)	Launch the classification of Plaque vs not plaque
   a.	Run for project the script named Analyse.groovy
   b.	Check the results
4)	Launch the measurement.groovy script. Les données sont automatiquement copiées sur un fichier Open Office nommé “out” 



Quantification des racines aortiques :

5)	Create project, sélectionner l'emplacement voulu pour enregistrer le nv projet
6)	Prepare the list of images
   a.	Import Images
7)	Faire la délimitation des aortes à la main (outil polygone)
8)	Launch the classification of Plaque vs not plaque
   a.	Automate> Shared scripts >AnalyseRacine.groovy   
   b.	Run> Run for project, add the list of image if needed in the right column.
   c.	Correct manually if needed : In pannel annotation, click on the Polygon, right click on the image, annotation-> Unlock ; Alt + drawing to erase a part.
9)	Launch the measurementsracine.groovy script. Les données sont automatiquement copiées sur un fichier Open Office nommé “outracine8”. Pour modifier “la sortie” (emplacement+nom) du fichier, cliquer sur Automate > Shared scripts > Measurementsracine.groovy > mettre le nouveau nom et emplacement au niveau de ce lien :
File file = new File("C:/Users/Axio Imager M2/Documents/MarineCoue/outracine16.csv");
