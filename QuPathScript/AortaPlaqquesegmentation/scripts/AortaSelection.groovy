setImageType('BRIGHTFIELD_H_DAB');
setColorDeconvolutionStains('{"Name" : "H-DAB default", "Stain 1" : "Hematoxylin", "Values 1" : "0.65111 0.70119 0.29049 ", "Stain 2" : "DAB", "Values 2" : "0.26917 0.56824 0.77759 ", "Background" : " 255 255 255 "}');
// Select tissue, only th emain aorta
runPlugin('qupath.imagej.detect.tissue.SimpleTissueDetection2', '{"threshold": 150,  "requestedPixelSizeMicrons": 20.0,  "minAreaMicrons": 1000000.0,  "maxHoleAreaMicrons": 1000000.0,  "darkBackground": false,  "smoothImage": true,  "medianCleanup": true,  "dilateBoundaries": false,  "smoothCoordinates": true,  "excludeOnBoundary": false,  "singleAnnotation": false}');
// crete tiles for analysis, here at 15 um 2