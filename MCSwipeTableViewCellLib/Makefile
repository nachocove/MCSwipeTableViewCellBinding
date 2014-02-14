
XBUILD=xcodebuild
PROJECT_ROOT=.
PROJECT=$(PROJECT_ROOT)/MCSwipeTableViewCellLib.xcodeproj
TARGET=MCSwipeTableViewCellLib

all: libMCSwipeTableViewCellLibSDK.a

libMCSwipeTableViewCellLib-i386.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphonesimulator/lib$(TARGET).a $@

libMCSwipeTableViewCellLib-armv7.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libMCSwipeTableViewCellLibSDK.a: libMCSwipeTableViewCellLib-i386.a libMCSwipeTableViewCellLib-armv7.a
	lipo -create -output $@ $^

clean:
	-rm -fr build
	-rm -f *.a *.dll
	-rm -fr ./MCSwipeTableViewCellLib.xcodeproj/project.xcworkspace
	-rm -fr ./MCSwipeTableViewCellLib.xcodeproj/xcuserdata
