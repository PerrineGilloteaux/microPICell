# DOCUMENTATION - Projet Microdissecteur

## Pré-requis (dossier install)

- Python39

## Arborescence du dossier du programme

```shell
Projet_microdissecteur
│   README.md
│   SCRIPT_PRINCIPAL.py   
│
└───Client
│   │   CTRemoteClient.application
│   │   setup.exe
│   │
│   └───Appplication files
│   
└───Coord
│    
└───Dependencies
│   │
│   └───Fiji.app
│  
└───Images
│       test.tiff
│   
└───Macro
        classifier.model
        get_ROI_ImageJ.ijm
        HE_segmentation.ijm
```

## Etapes à suivre

1. Allumer le microdissecteur et démarrer CellTools

2. Installer le client en exécutant le setup.exe

3. Lancer le client en exécutant le CTRemoteClien.application. Le dossier Projet_microdissecteur doit être mis au niveau c:/user/profile pour fonctionner.

## Erreurs rencontrées

- Error MK_E_UNAVAILABLE : il faut allumer le microdissecteur et CellTools avant de lancer l'application
