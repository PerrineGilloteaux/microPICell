
selectAnnotations();
runPlugin('qupath.lib.algorithms.TilerPlugin', '{"tileSizeMicrons": 15.0,  "trimToROI": true,  "makeAnnotations": false,  "removeParentAnnotation": false}');
// Compute intensity and texture feactures
selectDetections();
runPlugin('qupath.lib.algorithms.IntensityFeaturesPlugin', '{"pixelSizeMicrons": 2.0,  "region": "Square tiles",  "tileSizeMicrons": 15.0,  "colorOD": true,  "colorStain1": true,  "colorStain2": true,  "colorStain3": true,  "colorRed": true,  "colorGreen": false,  "colorBlue": true,  "colorHue": false,  "colorSaturation": true,  "colorBrightness": true,  "doMean": true,  "doStdDev": true,  "doMinMax": false,  "doMedian": false,  "doHaralick": true,  "haralickDistance": 1,  "haralickBins": 32}');
//Apply the precomputed classifier
runClassifier('C:\\Users\\Axio Imager M2\\Documents\\MarineCoue\\AorteEntiere\\classifiers\\NewclassifioerDoneWithMarine.qpclassifier');

