Author: Perrine Paul-Gilloteaux for Micropicell, Nantes, France

Ths plugin NDPI extract ROI will extract an imageJ roi or the full image at the desired resolution from an hammatsu NDPI file.

To install it:
-- FIRST Install Openslide
**for Windows 64 bits:
https://github.com/openslide/openslide-winbuild/releases/download/v20150527/openslide-win64-20150527.zip

** for Windows 32 bits 
https://github.com/openslide/openslide-winbuild/releases/download/v20150527/openslide-win32-20150527.zip

Unzip it and copy the bin directectory under your IJ/Fiji plugins directory. You can delete your dowlaod and any other directory from openslide.
Make sure to have copy the BIN directory: openslide functions should appear under plugins/bin/ now.

** for Linux: (here using git, otherwise copy/past the url content. 
git clone https://github.com/openslide/openslide 
then autoreconf -i
./configure
make
make install

-- SECOND Compile the .java
Launch ImageJ/Fiji
Install Plugin or compile and run it.

A jar version is also available but would depend on your java version, it can be recompiled in java 1.6 if required.
To compile:
javac -cp ../jars/ij-1.52f-SNAPSHOT.jar NDPI_extractROI.java (where ij-1.52f-SNAPSHOT.jar is the current ij lib of the Fiji installation)
-- THIRD: create a button: 

In order to get the NDPI button in the Fiji/IJ menu, add the following lines in StartupMacros.fiji.ijm (under the directory macros of your local fiji.app installation directory)
var sCmds = newMenu("NDPI Menu Tool",
	newArray("NDPI extractROI"));
macro "NDPI Menu Tool - CdddD05CbbbD15CdddL3545CaaaD55C999D65CaaaD75CeeeD85CdddD95C999La5b5CbbbDc5CeeeDd5CcccDe5CbbbD06C444D16CdddD26CaaaD36CbbbD46C888D56CeeeD66CdddD76C888D86CbbbD96CaaaDa6CeeeDb6C888Dc6CcccDd6C999De6CbbbD07C999D17C888D27C999D37CbbbD47C888D57D87CaaaD97C777Da7CaaaDb7C999Dc7CcccDd7C999De7CbbbL0828C555D38CbbbD48C888D58D88CaaaL98a8CeeeDb8CdddDd8C999De8CcccL0919C777D39CcccD49C888D59C999L6979CcccL89a9CeeeDd9CaaaDe9 " {
	cmd = getArgument();
	if (cmd!="-") run(cmd);
}
