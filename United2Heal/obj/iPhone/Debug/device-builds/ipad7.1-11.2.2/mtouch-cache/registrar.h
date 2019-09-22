#pragma clang diagnostic ignored "-Wdeprecated-declarations"
#pragma clang diagnostic ignored "-Wtypedef-redefinition"
#pragma clang diagnostic ignored "-Wobjc-designated-initializers"
#define DEBUG 1
#include <stdarg.h>
#include <objc/objc.h>
#include <objc/runtime.h>
#include <objc/message.h>
#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>
#import <AVFoundation/AVFoundation.h>
#import <QuartzCore/QuartzCore.h>
#import <CloudKit/CloudKit.h>
#import <Intents/Intents.h>
#import <CoreGraphics/CoreGraphics.h>

@protocol UIPickerViewModel;
@class __MonoMac_NSActionDispatcher;
@class __MonoMac_NSAsyncActionDispatcher;
@class UIKit_UIControlEventProxy;
@class AppDelegate;
@class itemCell;
@class United2Heal_BaseTableViewController;
@class United2Heal_ResultsTableController;
@class United2Heal_ItemTVS;
@class United2Heal_CategoryViewModel;
@class United2Heal_BaseTableViewControllerCat;
@class United2Heal_ResultsTableControllerCat;
@class categoryCell;
@class ViewController;
@class itemListController;
@class itemPage;
@class addNewItemPage;
@class catListController;
@class categoryPage;
@class __UIGestureRecognizerToken;
@class __UIGestureRecognizerParameterlessToken;
@class __UIGestureRecognizerParametrizedToken;
@class __NSObject_Disposer;
@class __UILongPressGestureRecognizer;
@class __UIPanGestureRecognizer;
@class UIKit_UIBarButtonItem_Callback;
@class __UIRotationGestureRecognizer;
@class __UITapGestureRecognizer;
@class __UIPinchGestureRecognizer;
@class __UISwipeGestureRecognizer;
@class __UIScreenEdgePanGestureRecognizer;
@class UIKit_UISearchBar__UISearchBarDelegate;
@class UIKit_UIScrollView__UIScrollViewDelegate;
@class ZXing_Mobile_CaptureDelegate;
@class ZXing_Mobile_AVCaptureScannerViewController;
@class ZXing_Mobile_ZXingScannerViewController;
@class ZXing_Mobile_AVCaptureScannerView;
@class ZXing_Mobile_ZXingDefaultOverlayView;
@class ZXing_Mobile_ZXingScannerView_OutputRecorder;
@class ZXing_Mobile_ZXingScannerView;

@protocol UIPickerViewModel<UIPickerViewDataSource, UIPickerViewDelegate>
@end

@interface AppDelegate : NSObject<UIApplicationDelegate> {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(UIWindow *) window;
	-(void) setWindow:(UIWindow *)p0;
	-(BOOL) application:(UIApplication *)p0 didFinishLaunchingWithOptions:(NSDictionary *)p1;
	-(void) applicationWillResignActive:(UIApplication *)p0;
	-(void) applicationDidEnterBackground:(UIApplication *)p0;
	-(void) applicationWillEnterForeground:(UIApplication *)p0;
	-(void) applicationDidBecomeActive:(UIApplication *)p0;
	-(void) applicationWillTerminate:(UIApplication *)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface itemCell : UITableViewCell {
}
	@property (nonatomic, assign) UILabel * itemCategory;
	@property (nonatomic, assign) UILabel * itemCode;
	@property (nonatomic, assign) UILabel * itemName;
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(UILabel *) itemCategory;
	-(void) setItemCategory:(UILabel *)p0;
	-(UILabel *) itemCode;
	-(void) setItemCode:(UILabel *)p0;
	-(UILabel *) itemName;
	-(void) setItemName:(UILabel *)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@interface United2Heal_BaseTableViewController : UITableViewController {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(void) viewDidLoad;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface United2Heal_ResultsTableController : United2Heal_BaseTableViewController {
}
	-(NSInteger) tableView:(UITableView *)p0 numberOfRowsInSection:(NSInteger)p1;
	-(UITableViewCell *) tableView:(UITableView *)p0 cellForRowAtIndexPath:(NSIndexPath *)p1;
	-(id) init;
@end

@interface United2Heal_BaseTableViewControllerCat : UITableViewController {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(void) viewDidLoad;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface United2Heal_ResultsTableControllerCat : United2Heal_BaseTableViewControllerCat {
}
	-(NSInteger) tableView:(UITableView *)p0 numberOfRowsInSection:(NSInteger)p1;
	-(UITableViewCell *) tableView:(UITableView *)p0 cellForRowAtIndexPath:(NSIndexPath *)p1;
	-(id) init;
@end

@interface categoryCell : UITableViewCell {
}
	@property (nonatomic, assign) UILabel * itemCategory;
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(UILabel *) itemCategory;
	-(void) setItemCategory:(UILabel *)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@interface ViewController : UIViewController {
}
	@property (nonatomic, assign) UIButton * addNewItemBtn;
	@property (nonatomic, assign) UIButton * closeBoxBtn;
	@property (nonatomic, assign) UIButton * exportExcelBtn;
	@property (nonatomic, assign) UIButton * searchBtn;
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(UIButton *) addNewItemBtn;
	-(void) setAddNewItemBtn:(UIButton *)p0;
	-(UIButton *) closeBoxBtn;
	-(void) setCloseBoxBtn:(UIButton *)p0;
	-(UIButton *) exportExcelBtn;
	-(void) setExportExcelBtn:(UIButton *)p0;
	-(UIButton *) searchBtn;
	-(void) setSearchBtn:(UIButton *)p0;
	-(void) viewDidLoad;
	-(void) prepareForSegue:(UIStoryboardSegue *)p0 sender:(NSObject *)p1;
	-(void) didReceiveMemoryWarning;
	-(void) AddNewItemBtn_TouchUpInside:(UIButton *)p0;
	-(void) ExportExcelBtn_TouchUpInside:(UIButton *)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@interface itemListController : UITableViewController {
}
	@property (nonatomic, assign) UITableView * tableView;
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(UITableView *) tableView;
	-(void) setTableView:(UITableView *)p0;
	-(void) viewDidLoad;
	-(void) updateSearchResultsForSearchController:(UISearchController *)p0;
	-(void) searchBarSearchButtonClicked:(UISearchBar *)p0;
	-(NSInteger) numberOfSectionsInTableView:(UITableView *)p0;
	-(NSInteger) tableView:(UITableView *)p0 numberOfRowsInSection:(NSInteger)p1;
	-(void) tableView:(UITableView *)p0 didSelectRowAtIndexPath:(NSIndexPath *)p1;
	-(UITableViewCell *) tableView:(UITableView *)p0 cellForRowAtIndexPath:(NSIndexPath *)p1;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface itemPage : UIViewController {
}
	@property (nonatomic, assign) UILabel * itemBox;
	@property (nonatomic, assign) UILabel * itemCategory;
	@property (nonatomic, assign) UILabel * itemCode;
	@property (nonatomic, assign) UILabel * itemName;
	@property (nonatomic, assign) UIView * itemPageView;
	@property (nonatomic, assign) UITextField * itemQuantField;
	@property (nonatomic, assign) UIButton * submit;
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(UILabel *) itemBox;
	-(void) setItemBox:(UILabel *)p0;
	-(UILabel *) itemCategory;
	-(void) setItemCategory:(UILabel *)p0;
	-(UILabel *) itemCode;
	-(void) setItemCode:(UILabel *)p0;
	-(UILabel *) itemName;
	-(void) setItemName:(UILabel *)p0;
	-(UIView *) itemPageView;
	-(void) setItemPageView:(UIView *)p0;
	-(UITextField *) itemQuantField;
	-(void) setItemQuantField:(UITextField *)p0;
	-(UIButton *) submit;
	-(void) setSubmit:(UIButton *)p0;
	-(void) viewDidLoad;
	-(void) didReceiveMemoryWarning;
	-(void) Submit_TouchUpInside:(UIButton *)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface addNewItemPage : UIViewController {
}
	@property (nonatomic, assign) UIPickerView * categoryPicker;
	@property (nonatomic, assign) UIButton * generateBtn;
	@property (nonatomic, assign) UILabel * itemBox;
	@property (nonatomic, assign) UITextField * itemCodeField;
	@property (nonatomic, assign) UITextField * itemNameField;
	@property (nonatomic, assign) UIButton * submitBtn;
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(UIPickerView *) categoryPicker;
	-(void) setCategoryPicker:(UIPickerView *)p0;
	-(UIButton *) generateBtn;
	-(void) setGenerateBtn:(UIButton *)p0;
	-(UILabel *) itemBox;
	-(void) setItemBox:(UILabel *)p0;
	-(UITextField *) itemCodeField;
	-(void) setItemCodeField:(UITextField *)p0;
	-(UITextField *) itemNameField;
	-(void) setItemNameField:(UITextField *)p0;
	-(UIButton *) submitBtn;
	-(void) setSubmitBtn:(UIButton *)p0;
	-(void) viewDidLoad;
	-(void) didReceiveMemoryWarning;
	-(void) GenerateBtn_TouchUpInside:(UIButton *)p0;
	-(void) SubmitBtn_TouchUpInside:(UIButton *)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@interface catListController : UITableViewController {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(void) viewDidLoad;
	-(void) updateSearchResultsForSearchController:(UISearchController *)p0;
	-(void) searchBarSearchButtonClicked:(UISearchBar *)p0;
	-(NSInteger) numberOfSectionsInTableView:(UITableView *)p0;
	-(NSInteger) tableView:(UITableView *)p0 numberOfRowsInSection:(NSInteger)p1;
	-(void) tableView:(UITableView *)p0 didSelectRowAtIndexPath:(NSIndexPath *)p1;
	-(UITableViewCell *) tableView:(UITableView *)p0 cellForRowAtIndexPath:(NSIndexPath *)p1;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@interface categoryPage : UIViewController {
}
	@property (nonatomic, assign) UILabel * categoryBox;
	@property (nonatomic, assign) UILabel * categoryName;
	@property (nonatomic, assign) UIButton * SubmitBtn;
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(UILabel *) categoryBox;
	-(void) setCategoryBox:(UILabel *)p0;
	-(UILabel *) categoryName;
	-(void) setCategoryName:(UILabel *)p0;
	-(UIButton *) SubmitBtn;
	-(void) setSubmitBtn:(UIButton *)p0;
	-(void) viewDidLoad;
	-(void) didReceiveMemoryWarning;
	-(void) SubmitBtn_TouchUpInside:(UIButton *)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface __UIGestureRecognizerToken : NSObject {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@interface __UIGestureRecognizerParameterlessToken : __UIGestureRecognizerToken {
}
	-(void) target;
@end

@interface __UIGestureRecognizerParametrizedToken : __UIGestureRecognizerToken {
}
	-(void) target:(UIGestureRecognizer *)p0;
@end

@interface ZXing_Mobile_AVCaptureScannerViewController : UIViewController {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(void) viewDidLoad;
	-(void) viewDidAppear:(BOOL)p0;
	-(void) viewDidDisappear:(BOOL)p0;
	-(void) viewWillDisappear:(BOOL)p0;
	-(void) didRotateFromInterfaceOrientation:(NSInteger)p0;
	-(BOOL) shouldAutorotate;
	-(NSUInteger) supportedInterfaceOrientations;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@interface ZXing_Mobile_ZXingScannerViewController : UIViewController {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(void) viewDidLoad;
	-(void) viewDidAppear:(BOOL)p0;
	-(void) viewDidDisappear:(BOOL)p0;
	-(void) viewWillDisappear:(BOOL)p0;
	-(void) didRotateFromInterfaceOrientation:(NSInteger)p0;
	-(BOOL) shouldAutorotate;
	-(NSUInteger) supportedInterfaceOrientations;
	-(BOOL) shouldAutorotateToInterfaceOrientation:(NSInteger)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@interface ZXing_Mobile_AVCaptureScannerView : UIView {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface ZXing_Mobile_ZXingDefaultOverlayView : UIView {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(void) layoutSubviews;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@interface ZXing_Mobile_ZXingScannerView_OutputRecorder : NSObject<AVCaptureVideoDataOutputSampleBufferDelegate> {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(void) captureOutput:(AVCaptureOutput *)p0 didDropSampleBuffer:(id)p1 fromConnection:(AVCaptureConnection *)p2;
	-(void) captureOutput:(AVCaptureOutput *)p0 didOutputSampleBuffer:(id)p1 fromConnection:(AVCaptureConnection *)p2;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@interface ZXing_Mobile_ZXingScannerView : UIView {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end


