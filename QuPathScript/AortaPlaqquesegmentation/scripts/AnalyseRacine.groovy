
selectAnnotations();
imageData = getCurrentImageData();
print(imageData);
runPlugin('qupath.lib.algorithms.TilerPlugin', '{"tileSizeMicrons": 3,  "trimToROI": true,  "makeAnnotations": false,  "removeParentAnnotation": false}');
// Compute intensity and texture feactures
selectDetections();
runPlugin('qupath.lib.algorithms.IntensityFeaturesPlugin', '{"pixelSizeMicrons": 1,  "region": "Square tiles",  "tileSizeMicrons": 3,  "colorOD": true,  "colorStain1": true,  "colorStain2": true,  "colorStain3": true,  "colorRed": true,  "colorGreen": false,  "colorBlue": true,  "colorHue": false,  "colorSaturation": true,  "colorBrightness": true,  "doMean": true,  "doStdDev": true,  "doMinMax": false,  "doMedian": false,  "doHaralick": true,  "haralickDistance": 1,  "haralickBins": 32}');
//Apply the precomputed classifier
runClassifier('C:\\Users\\Axio Imager M2\\Documents\\MarineCoue\\RacineAortique\\classifiers\\plaque.qpclassifier');
