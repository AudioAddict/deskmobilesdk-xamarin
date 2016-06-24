using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

/*
using System;
using Foundation;
using ObjCRuntime;
using UIKit;*/

namespace DeskKitSDK
{
    
        [Static]
        // TODO - [Verify (ConstantsInterfaceAssociation)]
        partial interface Constants
        {
        /*
            // extern double DeskKitVersionNumber;
            [Field ("DeskKitVersionNumber", "__Internal")]
            double DeskKitVersionNumber { get; }*/

        /*
            // extern const unsigned char [] DeskKitVersionString;
            [Field ("DeskKitVersionString", "__Internal")]
            byte[] DeskKitVersionString { get; }*/

        /*
        // extern NSString *const DSAPIDidErrorWithTooManyRequestsNotification;
        [Field ("DSAPIDidErrorWithTooManyRequestsNotification", "__Internal")]
        NSString DSAPIDidErrorWithTooManyRequestsNotification { get; }

        // extern NSString *const DSAPIResponseKey;
        [Field ("DSAPIResponseKey", "__Internal")]
        NSString DSAPIResponseKey { get; }

        // extern NSString *const DKContactUsViewControllerId;
        [Field ("DKContactUsViewControllerId", "__Internal")]
        NSString DKContactUsViewControllerId { get; }
        */
        }

        // typedef void (^DSAPIDownloadProgressHandler)(NSURLSession *, NSURLSessionDownloadTask *, int64_t, int64_t, int64_t);
        delegate void DSAPIDownloadProgressHandler (NSUrlSession arg0, NSUrlSessionDownloadTask arg1, long arg2, long arg3, long arg4);

        // typedef void (^DSAPIDownloadCompletionHandler)(NSData *, NSHTTPURLResponse *, NSError *);
        delegate void DSAPIDownloadCompletionHandler (NSData arg0, NSHttpUrlResponse arg1, NSError arg2);

        // @interface DSAPIClient : NSObject <NSURLSessionDelegate>
        [BaseType (typeof(NSObject))]
        interface DSAPIClient : INSUrlSessionDelegate
        {
        /*
            // @property (nonatomic, strong) int * accessToken;
            [Export ("accessToken", ArgumentSemantic.Strong)]
            unsafe int* AccessToken { get; set; }

            // @property (copy, nonatomic) NSURL * baseURL;
            [Export ("baseURL", ArgumentSemantic.Copy)]
            NSUrl BaseURL { get; set; }

            // @property (nonatomic, strong) int * requestSerializer;
            [Export ("requestSerializer", ArgumentSemantic.Strong)]
            unsafe int* RequestSerializer { get; set; }

            // @property (nonatomic, strong) int * responseSerializer;
            [Export ("responseSerializer", ArgumentSemantic.Strong)]
            unsafe int* ResponseSerializer { get; set; }*/

            // -(void)setHostname:(NSString *)hostname APIToken:(NSString *)apiToken;
            [Export ("setHostname:APIToken:")]
            void SetHostname (string hostname, string apiToken);

            // -(void)setHostname:(NSString *)hostname username:(NSString *)username password:(NSString *)password;
            [Export ("setHostname:username:password:")]
            void SetHostname (string hostname, string username, string password);

            // -(void)setHostname:(NSString *)hostname consumerKey:(NSString *)consumerKey consumerSecret:(NSString *)consumerSecret callbackURL:(NSURL *)callbackURL;
            [Export ("setHostname:consumerKey:consumerSecret:callbackURL:")]
            void SetHostname (string hostname, string consumerKey, string consumerSecret, NSUrl callbackURL);

            // -(Class)classForClassName:(NSString *)className;
            [Export ("classForClassName:")]
            Class ClassForClassName (string className);

            // -(void)postRateLimitingNotificationIfNecessary:(NSHTTPURLResponse *)response;
            [Export ("postRateLimitingNotificationIfNecessary:")]
            void PostRateLimitingNotificationIfNecessary (NSHttpUrlResponse response);

            // -(void)authorizeUsingOAuthWithQueue:(NSOperationQueue *)queue success:(void (^)(int *, NSURLRequest *))success failure:(id)failure;
            /*[Export ("authorizeUsingOAuthWithQueue:success:failure:")]
            unsafe void AuthorizeUsingOAuthWithQueue (NSOperationQueue queue, Action<int*, NSURLRequest> success, NSObject failure);

            // -(void)acquireOAuthRequestTokenWithQueue:(NSOperationQueue *)queue success:(void (^)(int *))success failure:(id)failure;
            [Export ("acquireOAuthRequestTokenWithQueue:success:failure:")]
            unsafe void AcquireOAuthRequestTokenWithQueue (NSOperationQueue queue, Action<int*> success, NSObject failure);

            // -(void)acquireOAuthAccessTokenWithRequestToken:(id)requestToken queue:(NSOperationQueue *)queue success:(void (^)(int *))success failure:(id)failure;
            [Export ("acquireOAuthAccessTokenWithRequestToken:queue:success:failure:")]
            unsafe void AcquireOAuthAccessTokenWithRequestToken (NSObject requestToken, NSOperationQueue queue, Action<int*> success, NSObject failure);

            // -(NSURLSessionDataTask *)dataTaskWithRequest:(NSURLRequest *)request queue:(NSOperationQueue *)queue success:(void (^)(NSHTTPURLResponse *, id))success failure:(void (^)(NSHTTPURLResponse *, NSError *))failure;
            [Export ("dataTaskWithRequest:queue:success:failure:")]
            NSUrlSessionDataTask DataTaskWithRequest (NSUrlRequest request, NSOperationQueue queue, Action<NSHTTPURLResponse, NSObject> success, Action<NSHTTPURLResponse, NSError> failure);

            // -(NSURLSessionDataTask *)GET:(NSString *)URLString parameters:(id)parameters queue:(NSOperationQueue *)queue success:(void (^)(NSHTTPURLResponse *, id))success failure:(void (^)(NSHTTPURLResponse *, NSError *))failure;
            [Export ("GET:parameters:queue:success:failure:")]
            NSUrlSessionDataTask GET (string URLString, NSObject parameters, NSOperationQueue queue, Action<NSHTTPURLResponse, NSObject> success, Action<NSHTTPURLResponse, NSError> failure);

            // -(NSURLSessionDataTask *)POST:(NSString *)URLString parameters:(id)parameters queue:(NSOperationQueue *)queue success:(void (^)(NSHTTPURLResponse *, id))success failure:(void (^)(NSHTTPURLResponse *, NSError *))failure;
            [Export ("POST:parameters:queue:success:failure:")]
            NSUrlSessionDataTask POST (string URLString, NSObject parameters, NSOperationQueue queue, Action<NSHTTPURLResponse, NSObject> success, Action<NSHTTPURLResponse, NSError> failure);

            // -(NSURLSessionDataTask *)PUT:(NSString *)URLString parameters:(id)parameters queue:(NSOperationQueue *)queue success:(void (^)(NSHTTPURLResponse *, id))success failure:(void (^)(NSHTTPURLResponse *, NSError *))failure;
            [Export ("PUT:parameters:queue:success:failure:")]
            NSUrlSessionDataTask PUT (string URLString, NSObject parameters, NSOperationQueue queue, Action<NSHTTPURLResponse, NSObject> success, Action<NSHTTPURLResponse, NSError> failure);

            // -(NSURLSessionDataTask *)PATCH:(NSString *)URLString parameters:(id)parameters queue:(NSOperationQueue *)queue success:(void (^)(NSHTTPURLResponse *, id))success failure:(void (^)(NSHTTPURLResponse *, NSError *))failure;
            [Export ("PATCH:parameters:queue:success:failure:")]
            NSUrlSessionDataTask PATCH (string URLString, NSObject parameters, NSOperationQueue queue, Action<NSHTTPURLResponse, NSObject> success, Action<NSHTTPURLResponse, NSError> failure);

            // -(NSURLSessionDataTask *)DELETE:(NSString *)URLString parameters:(id)parameters queue:(NSOperationQueue *)queue success:(void (^)(NSHTTPURLResponse *, id))success failure:(void (^)(NSHTTPURLResponse *, NSError *))failure;
            [Export ("DELETE:parameters:queue:success:failure:")]
            NSUrlSessionDataTask DELETE (string URLString, NSObject parameters, NSOperationQueue queue, Action<NSHTTPURLResponse, NSObject> success, Action<NSHTTPURLResponse, NSError> failure);
*/
            // -(void)cancelAllDataTasksWithQueue:(NSOperationQueue *)queue completionHandler:(void (^)(void))completionHandler;
            [Export ("cancelAllDataTasksWithQueue:completionHandler:")]
            void CancelAllDataTasksWithQueue (NSOperationQueue queue, Action completionHandler);

            // -(NSURLSessionDownloadTask *)downloadTaskWithURL:(NSURL *)url queue:(NSOperationQueue *)queue progressHandler:(DSAPIDownloadProgressHandler)progressHandler completionHandler:(DSAPIDownloadCompletionHandler)completionHandler;
            [Export ("downloadTaskWithURL:queue:progressHandler:completionHandler:")]
            NSUrlSessionDownloadTask DownloadTaskWithURL (NSUrl url, NSOperationQueue queue, DSAPIDownloadProgressHandler progressHandler, DSAPIDownloadCompletionHandler completionHandler);

            // -(void)cancelAllDownloadTasksWithQueue:(NSOperationQueue *)queue completionHandler:(void (^)(void))completionHandler;
            [Export ("cancelAllDownloadTasksWithQueue:completionHandler:")]
            void CancelAllDownloadTasksWithQueue (NSOperationQueue queue, Action completionHandler);

            // -(void)resetSessionWithCompletionHandler:(void (^)(void))completionHandler;
            [Export ("resetSessionWithCompletionHandler:")]
            void ResetSessionWithCompletionHandler (Action completionHandler);
        }

        // typedef void (^DSAPIPageSuccessBlock)(DSAPIPage *);
        delegate void DSAPIPageSuccessBlock (DSAPIPage arg0);

        // typedef void (^DSAPIResourceSuccessBlock)(DSAPIResource *);
        delegate void DSAPIResourceSuccessBlock (DSAPIResource arg0);

        // typedef void (^DSAPIFailureBlock)(NSHTTPURLResponse *, NSError *);
        delegate void DSAPIFailureBlock (NSHttpUrlResponse arg0, NSError arg1);

        // @interface DSAPILink : NSObject
        [BaseType (typeof(NSObject))]
        interface DSAPILink
        {
            // @property (readonly, copy, nonatomic) NSString * href;
            [Export ("href")]
            string Href { get; }

            // @property (readonly, copy, nonatomic) NSString * className;
            [Export ("className")]
            string ClassName { get; }

            // @property (readonly, nonatomic, strong) NSURL * URL;
            [Export ("URL", ArgumentSemantic.Strong)]
            NSUrl URL { get; }

            // @property (readonly, nonatomic, strong) NSDictionary * parameters;
            [Export ("parameters", ArgumentSemantic.Strong)]
            NSDictionary Parameters { get; }

            // @property (readonly, nonatomic) NSDictionary * dictionary;
            [Export ("dictionary")]
            NSDictionary Dictionary { get; }

            // +(instancetype)linkWithHref:(NSString *)href className:(NSString *)className baseURL:(NSURL *)baseURL;
            [Static]
            [Export ("linkWithHref:className:baseURL:")]
            DSAPILink LinkWithHref (string href, string className, NSUrl baseURL);

            // -(instancetype)initWithDictionary:(NSDictionary *)dictionary baseURL:(NSURL *)baseURL;
            [Export ("initWithDictionary:baseURL:")]
            IntPtr Constructor (NSDictionary dictionary, NSUrl baseURL);

            // -(DSAPILink *)linkFromRelationWithClass:(Class)relatedClass;
            [Export ("linkFromRelationWithClass:")]
            DSAPILink LinkFromRelationWithClass (Class relatedClass);

            // -(DSAPIResource *)resourceWithClient:(DSAPIClient *)client;
            [Export ("resourceWithClient:")]
            DSAPIResource ResourceWithClient (DSAPIClient client);
        }

        // @interface DSAPIResource : NSObject
        [BaseType (typeof(NSObject))]
        interface DSAPIResource
        {
            // @property (readonly, nonatomic) NSDictionary * links;
            [Export ("links")]
            NSDictionary Links { get; }

            // @property (readonly, nonatomic) NSDictionary * dictionary;
            [Export ("dictionary")]
            NSDictionary Dictionary { get; }

            // @property (readonly, nonatomic) DSAPILink * linkToSelf;
            [Export ("linkToSelf")]
            DSAPILink LinkToSelf { get; }

            // @property (readonly, nonatomic, weak) DSAPIClient * _Nullable client;
            [NullAllowed, Export ("client", ArgumentSemantic.Weak)]
            DSAPIClient Client { get; }

            // +(DSAPILink *)classLinkWithBaseURL:(NSURL *)baseURL;
            [Static]
            [Export ("classLinkWithBaseURL:")]
            DSAPILink ClassLinkWithBaseURL (NSUrl baseURL);

            // +(NSString *)className;
            [Static]
            [Export ("className")]
            // TODO - [Verify (MethodToProperty)]
            string ClassName { get; }

            // +(NSString *)classNamePlural;
            [Static]
            [Export ("classNamePlural")]
            // TODO - [Verify (MethodToProperty)]
            string ClassNamePlural { get; }

            // +(DSAPIResource *)resourceWithHref:(NSString *)href client:(DSAPIClient *)client className:(NSString *)className;
            [Static]
            [Export ("resourceWithHref:client:className:")]
            DSAPIResource ResourceWithHref (string href, DSAPIClient client, string className);

            // +(DSAPIResource *)resourceWithId:(NSString *)resourceId client:(DSAPIClient *)client className:(NSString *)className;
            [Static]
            [Export ("resourceWithId:client:className:")]
            DSAPIResource ResourceWithId (string resourceId, DSAPIClient client, string className);

            // -(id)initWithDictionary:(NSDictionary *)dictionary client:(DSAPIClient *)client;
            [Export ("initWithDictionary:client:")]
            IntPtr Constructor (NSDictionary dictionary, DSAPIClient client);

            // -(DSAPILink *)linkForRelation:(NSString *)relation;
            [Export ("linkForRelation:")]
            DSAPILink LinkForRelation (string relation);

            // -(DSAPILink *)linkForRelation:(NSString *)relation className:(NSString *)className;
            [Export ("linkForRelation:className:")]
            DSAPILink LinkForRelation (string relation, string className);

            // -(NSArray *)linksForRelation:(NSString *)relation;
            [Export ("linksForRelation:")]
            // TODO - [Verify (StronglyTypedNSArray)]
            NSObject[] LinksForRelation (string relation);

            // -(DSAPIResource *)resourceForRelation:(NSString *)relation;
            [Export ("resourceForRelation:")]
            DSAPIResource ResourceForRelation (string relation);

            // -(NSArray *)resourcesForRelation:(NSString *)relation;
            [Export ("resourcesForRelation:")]
            // TODO - [Verify (StronglyTypedNSArray)]
            NSObject[] ResourcesForRelation (string relation);

            // -(void)setObject:(id)obj forKeyedSubscript:(id<NSCopying>)key;
            [Export ("setObject:forKeyedSubscript:")]
            void SetObject (NSObject obj, NSCopying key);

            // -(id)objectForKeyedSubscript:(id)key;
            [Export ("objectForKeyedSubscript:")]
            NSObject ObjectForKeyedSubscript (NSObject key);

            // +(NSURLSessionDataTask *)listResourcesAt:(DSAPILink *)link parameters:(NSDictionary *)parameters client:(DSAPIClient *)client queue:(NSOperationQueue *)queue success:(DSAPIPageSuccessBlock)success failure:(DSAPIFailureBlock)failure;
            [Static]
            [Export ("listResourcesAt:parameters:client:queue:success:failure:")]
            NSUrlSessionDataTask ListResourcesAt (DSAPILink link, NSDictionary parameters, DSAPIClient client, NSOperationQueue queue, DSAPIPageSuccessBlock success, DSAPIFailureBlock failure);

            // +(NSURLSessionDataTask *)listResourcesAt:(DSAPILink *)link parameters:(NSDictionary *)parameters client:(DSAPIClient *)client queue:(NSOperationQueue *)queue success:(DSAPIPageSuccessBlock)success notModified:(DSAPIPageSuccessBlock)notModified failure:(DSAPIFailureBlock)failure;
            [Static]
            [Export ("listResourcesAt:parameters:client:queue:success:notModified:failure:")]
            NSUrlSessionDataTask ListResourcesAt (DSAPILink link, NSDictionary parameters, DSAPIClient client, NSOperationQueue queue, DSAPIPageSuccessBlock success, DSAPIPageSuccessBlock notModified, DSAPIFailureBlock failure);

            // +(NSURLSessionDataTask *)searchResourcesAt:(DSAPILink *)classLink parameters:(NSDictionary *)parameters client:(DSAPIClient *)client queue:(NSOperationQueue *)queue success:(DSAPIPageSuccessBlock)success failure:(DSAPIFailureBlock)failure;
            [Static]
            [Export ("searchResourcesAt:parameters:client:queue:success:failure:")]
            NSUrlSessionDataTask SearchResourcesAt (DSAPILink classLink, NSDictionary parameters, DSAPIClient client, NSOperationQueue queue, DSAPIPageSuccessBlock success, DSAPIFailureBlock failure);

            // +(NSURLSessionDataTask *)searchResourcesAt:(DSAPILink *)classLink parameters:(NSDictionary *)parameters client:(DSAPIClient *)client queue:(NSOperationQueue *)queue success:(DSAPIPageSuccessBlock)success notModified:(DSAPIPageSuccessBlock)notModified failure:(DSAPIFailureBlock)failure;
            [Static]
            [Export ("searchResourcesAt:parameters:client:queue:success:notModified:failure:")]
            NSUrlSessionDataTask SearchResourcesAt (DSAPILink classLink, NSDictionary parameters, DSAPIClient client, NSOperationQueue queue, DSAPIPageSuccessBlock success, DSAPIPageSuccessBlock notModified, DSAPIFailureBlock failure);

            // +(DSAPILink *)searchEndpointForClassLink:(DSAPILink *)classLink client:(DSAPIClient *)client;
            [Static]
            [Export ("searchEndpointForClassLink:client:")]
            DSAPILink SearchEndpointForClassLink (DSAPILink classLink, DSAPIClient client);

            // +(NSURLSessionDataTask *)createResource:(NSDictionary *)resourceDict link:(DSAPILink *)link client:(DSAPIClient *)client queue:(NSOperationQueue *)queue success:(DSAPIResourceSuccessBlock)success failure:(DSAPIFailureBlock)failure;
            [Static]
            [Export ("createResource:link:client:queue:success:failure:")]
            NSUrlSessionDataTask CreateResource (NSDictionary resourceDict, DSAPILink link, DSAPIClient client, NSOperationQueue queue, DSAPIResourceSuccessBlock success, DSAPIFailureBlock failure);

            // +(NSURLSessionDataTask *)showResourceAtLink:(DSAPILink *)linkToResource parameters:(NSDictionary *)parameters client:(DSAPIClient *)client queue:(NSOperationQueue *)queue success:(DSAPIResourceSuccessBlock)success failure:(DSAPIFailureBlock)failure;
            [Static]
            [Export ("showResourceAtLink:parameters:client:queue:success:failure:")]
            NSUrlSessionDataTask ShowResourceAtLink (DSAPILink linkToResource, NSDictionary parameters, DSAPIClient client, NSOperationQueue queue, DSAPIResourceSuccessBlock success, DSAPIFailureBlock failure);

            // -(NSURLSessionDataTask *)showWithParameters:(NSDictionary *)parameters queue:(NSOperationQueue *)queue success:(DSAPIResourceSuccessBlock)success failure:(DSAPIFailureBlock)failure;
            [Export ("showWithParameters:queue:success:failure:")]
            NSUrlSessionDataTask ShowWithParameters (NSDictionary parameters, NSOperationQueue queue, DSAPIResourceSuccessBlock success, DSAPIFailureBlock failure);

            // -(NSURLSessionDataTask *)updateWithDictionary:(NSDictionary *)dictionary queue:(NSOperationQueue *)queue success:(DSAPIResourceSuccessBlock)success failure:(DSAPIFailureBlock)failure;
            [Export ("updateWithDictionary:queue:success:failure:")]
            NSUrlSessionDataTask UpdateWithDictionary (NSDictionary dictionary, NSOperationQueue queue, DSAPIResourceSuccessBlock success, DSAPIFailureBlock failure);

            // -(NSURLSessionDataTask *)listResourcesForRelation:(NSString *)relation parameters:(NSDictionary *)parameters queue:(NSOperationQueue *)queue success:(DSAPIPageSuccessBlock)success failure:(DSAPIFailureBlock)failure;
            [Export ("listResourcesForRelation:parameters:queue:success:failure:")]
            NSUrlSessionDataTask ListResourcesForRelation (string relation, NSDictionary parameters, NSOperationQueue queue, DSAPIPageSuccessBlock success, DSAPIFailureBlock failure);

            // -(NSURLSessionDataTask *)listResourcesForRelation:(NSString *)relation parameters:(NSDictionary *)parameters queue:(NSOperationQueue *)queue success:(DSAPIPageSuccessBlock)success notModified:(DSAPIPageSuccessBlock)notModified failure:(DSAPIFailureBlock)failure;
            [Export ("listResourcesForRelation:parameters:queue:success:notModified:failure:")]
            NSUrlSessionDataTask ListResourcesForRelation (string relation, NSDictionary parameters, NSOperationQueue queue, DSAPIPageSuccessBlock success, DSAPIPageSuccessBlock notModified, DSAPIFailureBlock failure);

            // -(NSURLSessionDataTask *)deleteWithParameters:(NSDictionary *)parameters queue:(NSOperationQueue *)queue success:(void (^)(void))success failure:(DSAPIFailureBlock)failure;
            [Export ("deleteWithParameters:queue:success:failure:")]
            NSUrlSessionDataTask DeleteWithParameters (NSDictionary parameters, NSOperationQueue queue, Action success, DSAPIFailureBlock failure);

            // -(NSString *)idFromSelfLink;
            [Export ("idFromSelfLink")]
            // TODO - [Verify (MethodToProperty)]
            string IdFromSelfLink { get; }
        }

        // @interface DSAPIPage : DSAPIResource
        [BaseType (typeof(DSAPIResource))]
        interface DSAPIPage
        {
            // @property (readonly, nonatomic) NSArray * entries;
            [Export ("entries")]
            // TODO - [Verify (StronglyTypedNSArray)]
            NSObject[] Entries { get; }

            // @property (readonly, nonatomic) NSArray * newEntries;
            [Export ("newEntries")]
            // TODO - [Verify (StronglyTypedNSArray)]
            NSObject[] NewEntries { get; }

            // @property (readonly, nonatomic) NSArray * changedEntries;
            [Export ("changedEntries")]
            // TODO - [Verify (StronglyTypedNSArray)]
            NSObject[] ChangedEntries { get; }

            // @property (readonly, nonatomic) NSArray * removedEntries;
            [Export ("removedEntries")]
            // TODO - [Verify (StronglyTypedNSArray)]
            NSObject[] RemovedEntries { get; }

            // @property (readonly, nonatomic) NSArray * positions;
            [Export ("positions")]
            // TODO - [Verify (StronglyTypedNSArray)]
            NSObject[] Positions { get; }

            // @property (readonly, nonatomic) NSNumber * time;
            [Export ("time")]
            NSNumber Time { get; }

            // @property (readonly, nonatomic) NSNumber * totalEntries;
            [Export ("totalEntries")]
            NSNumber TotalEntries { get; }

            // @property (readonly, nonatomic) NSUInteger pageNumber;
            [Export ("pageNumber")]
            nuint PageNumber { get; }

            // @property (readonly, nonatomic) NSUInteger perPage;
            [Export ("perPage")]
            nuint PerPage { get; }

            // @property (readonly, nonatomic) DSAPILink * linkToFirstPage;
            [Export ("linkToFirstPage")]
            DSAPILink LinkToFirstPage { get; }

            // @property (readonly, nonatomic) DSAPILink * linkToLastPage;
            [Export ("linkToLastPage")]
            DSAPILink LinkToLastPage { get; }

            // @property (readonly, nonatomic) DSAPILink * linkToPreviousPage;
            [Export ("linkToPreviousPage")]
            DSAPILink LinkToPreviousPage { get; }

            // @property (readonly, nonatomic) DSAPILink * linkToNextPage;
            [Export ("linkToNextPage")]
            DSAPILink LinkToNextPage { get; }

            // @property (readonly, nonatomic) BOOL shouldLoadNextPage;
            [Export ("shouldLoadNextPage")]
            bool ShouldLoadNextPage { get; }

            // @property (nonatomic) BOOL notModified;
            [Export ("notModified")]
            bool NotModified { get; set; }

            // +(DSAPIPage *)pageFromPageHref:(NSString *)currentPageHref withNextPageHref:(NSString *)nextPageHref client:(DSAPIClient *)client;
            [Static]
            [Export ("pageFromPageHref:withNextPageHref:client:")]
            DSAPIPage PageFromPageHref (string currentPageHref, string nextPageHref, DSAPIClient client);
        }

        // @interface DSAPIListProvider : NSObject
        [BaseType (typeof(NSObject))]
        interface DSAPIListProvider
        {
            // @property (readonly, nonatomic) NSInteger totalPages;
            [Export ("totalPages")]
            nint TotalPages { get; }

            // @property (readonly, nonatomic) NSUInteger resourcesPerPage;
            [Export ("resourcesPerPage")]
            nuint ResourcesPerPage { get; }

            [Wrap ("WeakDelegate")]
            [NullAllowed]
            DSAPIListProviderDelegate Delegate { get; set; }

            // @property (nonatomic, weak) id<DSAPIListProviderDelegate> _Nullable delegate;
            [NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
            NSObject WeakDelegate { get; set; }

            // @property (readonly, nonatomic) id<DSAPIListEndpoint> endpoint;
            [Export ("endpoint")]
            DSAPIListEndpoint Endpoint { get; }

            // -(instancetype)initWithEndpoint:(id<DSAPIListEndpoint>)endpoint;
            [Export ("initWithEndpoint:")]
            IntPtr Constructor (DSAPIListEndpoint endpoint);

            // -(void)reset;
            [Export ("reset")]
            void Reset ();

            // -(NSInteger)numberOfResourcesOnPageNumber:(NSUInteger)pageNumber;
            [Export ("numberOfResourcesOnPageNumber:")]
            nint NumberOfResourcesOnPageNumber (nuint pageNumber);

            // -(DSAPIResource *)resourceOnPageNumber:(NSUInteger)pageNumber inRow:(NSUInteger)row;
            [Export ("resourceOnPageNumber:inRow:")]
            DSAPIResource ResourceOnPageNumber (nuint pageNumber, nuint row);

            // -(void)fetchResourcesOnPageNumber:(NSUInteger)pageNumber;
            [Export ("fetchResourcesOnPageNumber:")]
            void FetchResourcesOnPageNumber (nuint pageNumber);
        }

        // @protocol DSAPIListProviderDelegate <NSObject>
        [Protocol, Model]
        [BaseType (typeof(NSObject))]
        interface DSAPIListProviderDelegate
        {
            // @optional -(void)listProvider:(DSAPIListProvider *)listProvider willFetchPageNumber:(NSUInteger)pageNumber;
            [Export ("listProvider:willFetchPageNumber:")]
            void ListProvider (DSAPIListProvider listProvider, nuint pageNumber);

            // @optional -(void)listProvider:(DSAPIListProvider *)listProvider didFetchPage:(DSAPIPage *)page;
            [Export ("listProvider:didFetchPage:")]
            void ListProvider (DSAPIListProvider listProvider, DSAPIPage page);

            // @optional -(void)listProvider:(DSAPIListProvider *)listProvider fetchDidFailOnPageNumber:(NSUInteger)pageNumber;
            //[Export ("listProvider:fetchDidFailOnPageNumber:")]
            //void ListProvider (DSAPIListProvider listProvider, nuint pageNumber);

            // @optional -(void)listProviderDidFetchNoResults:(DSAPIListProvider *)listProvider;
            [Export ("listProviderDidFetchNoResults:")]
            void ListProviderDidFetchNoResults (DSAPIListProvider listProvider);
        }

        // @protocol DSAPIListEndpoint <NSObject>
        [Protocol, Model]
        [BaseType (typeof(NSObject))]
        interface DSAPIListEndpoint
        {
            // @required @property (nonatomic) NSUInteger perPage;
            [Export ("perPage")]
            nuint PerPage { get; set; }

            // @required -(void)listResourcesOnPageNumber:(NSUInteger)pageNumber queue:(NSOperationQueue *)queue success:(DSAPIPageSuccessBlock)success failure:(DSAPIFailureBlock)failure;
            [Abstract]
            [Export ("listResourcesOnPageNumber:queue:success:failure:")]
            void Queue (nuint pageNumber, NSOperationQueue queue, DSAPIPageSuccessBlock success, DSAPIFailureBlock failure);
        }

        // @interface DKSession : NSObject
        [BaseType (typeof(NSObject))]
        interface DKSession
        {
            // @property (readonly, nonatomic) NSURL * _Nullable contactUsPhoneNumberURL;
            [NullAllowed, Export ("contactUsPhoneNumberURL")]
            NSUrl ContactUsPhoneNumberURL { get; }

            // +(void)startWithHostname:(NSString * _Nonnull)hostname APIToken:(NSString * _Nonnull)APIToken;
            [Static]
            [Export ("startWithHostname:APIToken:")]
            void StartWithHostname (string hostname, string APIToken);

            // +(instancetype _Nonnull)sharedInstance;
            [Static]
            [Export ("sharedInstance")]
            DKSession SharedInstance ();

            // +(BOOL)isSessionStarted;
            [Static]
            [Export ("isSessionStarted")]
            // TODO - [Verify (MethodToProperty)]
            bool IsSessionStarted { get; }

            // +(id)newTopicsViewController;
            [Static]
            [Export ("newTopicsViewController")]
            // TODO - [Verify (MethodToProperty)]
            NSObject NewTopicsViewController { get; }

            // +(id)newArticlesViewController;
            [Static]
            [Export ("newArticlesViewController")]
            // TODO - [Verify (MethodToProperty)]
            NSObject NewArticlesViewController { get; }

            // +(UIAlertController * _Nonnull)newContactUsAlertControllerWithCallHandler:(void (^ _Nonnull)(UIAlertAction * _Nonnull))callHandler emailHandler:(void (^ _Nonnull)(UIAlertAction * _Nonnull))emailHandler;
            [Static]
            [Export ("newContactUsAlertControllerWithCallHandler:emailHandler:")]
            UIAlertController NewContactUsAlertControllerWithCallHandler (Action<UIAlertAction> callHandler, Action<UIAlertAction> emailHandler);

            // -(id)newContactUsViewController;
            [Export ("newContactUsViewController")]
            // TODO - [Verify (MethodToProperty)]
            NSObject NewContactUsViewController();

            // +(id)newArticleDetailViewController;
            [Static]
            [Export ("newArticleDetailViewController")]
            // TODO - [Verify (MethodToProperty)]
            NSObject NewArticleDetailViewController { get; }

            // +(id)newSearchResultsViewController;
            [Static]
            [Export ("newSearchResultsViewController")]
            // TODO - [Verify (MethodToProperty)]
            NSObject NewSearchResultsViewController { get; }

            // +(BOOL)hasContactUsPhoneNumber;
            [Static]
            [Export ("hasContactUsPhoneNumber")]
            // TODO - [Verify (MethodToProperty)]
            bool HasContactUsPhoneNumber { get; }

            // -(NSString * _Nullable)contactUsToEmailAddress;
            [NullAllowed, Export ("contactUsToEmailAddress")]
            // TODO - [Verify (MethodToProperty)]
            string ContactUsToEmailAddress { get; }

            // -(void)hasContactUsToEmailAddressWithCompletionHandler:(void (^ _Nonnull)(BOOL))completionHandler;
            [Export ("hasContactUsToEmailAddressWithCompletionHandler:")]
            void HasContactUsToEmailAddressWithCompletionHandler (Action<bool> completionHandler);
        }

    // @protocol DKContactUsViewControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType (typeof(NSObject))]
    interface DKContactUsViewControllerDelegate
    {
        // @required -(void)contactUsViewControllerDidSendMessage:(DKContactUsViewController *)viewController;
        [Abstract]
        [Export ("contactUsViewControllerDidSendMessage:")]
        void ContactUsViewControllerDidSendMessage (DKContactUsViewController viewController);

        // @required -(void)contactUsViewControllerDidCancel:(DKContactUsViewController *)viewController;
        [Abstract]
        [Export ("contactUsViewControllerDidCancel:")]
        void ContactUsViewControllerDidCancel (DKContactUsViewController viewController);
    }

    // @interface DKContactUsViewController : UITableViewController
    [BaseType (typeof(UITableViewController))]
    interface DKContactUsViewController
    {
        [Wrap ("WeakDelegate")]
        [NullAllowed]
        DKContactUsViewControllerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<DKContactUsViewControllerDelegate> _Nullable delegate;
        [NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (nonatomic) int * userIdentity;
        [Export ("userIdentity", ArgumentSemantic.Assign)]
        DKUserIdentity UserIdentity { get; set; }

        // @property (copy, nonatomic) NSString * subject;
        [Export ("subject")]
        string Subject { get; set; }

        // @property (copy, nonatomic) NSString * toEmailAddress;
        [Export ("toEmailAddress")]
        string ToEmailAddress { get; set; }

        // @property (copy, nonatomic) NSDictionary * customFields;
        [Export ("customFields", ArgumentSemantic.Copy)]
        NSDictionary CustomFields { get; set; }

        // @property (nonatomic) BOOL showAllOptionalItems;
        [Export ("showAllOptionalItems")]
        bool ShowAllOptionalItems { get; set; }

        // @property (nonatomic) BOOL showYourNameItem;
        [Export ("showYourNameItem")]
        bool ShowYourNameItem { get; set; }

        // @property (nonatomic) BOOL showYourEmailItem;
        [Export ("showYourEmailItem")]
        bool ShowYourEmailItem { get; set; }

        // @property (nonatomic) BOOL showSubjectItem;
        [Export ("showSubjectItem")]
        bool ShowSubjectItem { get; set; }
    }

    // @interface DKContactUsViewModel : NSObject
    [BaseType (typeof(NSObject))]
    interface DKContactUsViewModel
    {
        // @property (readonly, nonatomic) NSArray * sections;
        [Export ("sections")]
        //[Verify (StronglyTypedNSArray)]
        NSObject[] Sections { get; }

        // @property (readonly, nonatomic) NSIndexPath * messageIndexPath;
        [Export ("messageIndexPath")]
        NSIndexPath MessageIndexPath { get; }

        // @property (nonatomic) int * userIdentity;
        [Export ("userIdentity", ArgumentSemantic.Assign)]
        DKUserIdentity UserIdentity { get; set; }

        // @property (copy, nonatomic) NSString * subject;
        [Export ("subject")]
        string Subject { get; set; }

        // @property (copy, nonatomic) NSString * toEmailAddress;
        [Export ("toEmailAddress")]
        string ToEmailAddress { get; set; }

        // @property (copy, nonatomic) NSDictionary * customFields;
        [Export ("customFields", ArgumentSemantic.Copy)]
        NSDictionary CustomFields { get; set; }

        // @property (copy, nonatomic) NSString * nameItemIdentifier;
        [Export ("nameItemIdentifier")]
        string NameItemIdentifier { get; set; }

        // @property (copy, nonatomic) NSString * emailItemIdentifier;
        [Export ("emailItemIdentifier")]
        string EmailItemIdentifier { get; set; }

        // @property (copy, nonatomic) NSString * subjectItemIdentifier;
        [Export ("subjectItemIdentifier")]
        string SubjectItemIdentifier { get; set; }

        // @property (copy, nonatomic) NSString * messageBodyItemIdentifier;
        [Export ("messageBodyItemIdentifier")]
        string MessageBodyItemIdentifier { get; set; }

        // @property (nonatomic) BOOL includeAllOptionalItems;
        [Export ("includeAllOptionalItems")]
        bool IncludeAllOptionalItems { get; set; }

        // @property (nonatomic) BOOL includeYourNameItem;
        [Export ("includeYourNameItem")]
        bool IncludeYourNameItem { get; set; }

        // @property (nonatomic) BOOL includeYourEmailItem;
        [Export ("includeYourEmailItem")]
        bool IncludeYourEmailItem { get; set; }

        // @property (nonatomic) BOOL includeSubjectItem;
        [Export ("includeSubjectItem")]
        bool IncludeSubjectItem { get; set; }

        // -(instancetype)initIncludingOptionalItems:(BOOL)include;
        [Export ("initIncludingOptionalItems:")]
        IntPtr Constructor (bool include);

        // -(void)updateText:(NSAttributedString *)text indexPath:(NSIndexPath *)indexPath;
        [Export ("updateText:indexPath:")]
        void UpdateText (NSAttributedString text, NSIndexPath indexPath);

        // -(BOOL)isValidEmailCase;
        [Export ("isValidEmailCase")]
        bool IsValidEmailCase();

		// -(BOOL)validFromEmail;
		[Export("validFromEmail")]
		bool ValidFromEmail();

        // -(NSURLSessionDataTask *)createEmailCaseWithQueue:(NSOperationQueue *)queue success:(void (^)(int *))success failure:(id)failure;
        [Export ("createEmailCaseWithQueue:success:failure:")]
        NSUrlSessionDataTask CreateEmailCaseWithQueue (NSOperationQueue queue, Action<DSAPICase> success, DSAPIFailureBlock failure);
    }

    // @interface DKUserIdentity : NSObject
    [BaseType (typeof(NSObject))]
    interface DKUserIdentity
    {
        // @property (copy, nonatomic) NSString * _Nonnull givenName;
        [Export ("givenName")]
        string GivenName { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull familyName;
        [Export ("familyName")]
        string FamilyName { get; set; }

        // @property (readonly, nonatomic) NSString * _Nonnull fullName;
        [Export ("fullName")]
        string FullName { get; }

        // @property (copy, nonatomic) NSString * _Nonnull email;
        [Export ("email")]
        string Email { get; set; }

        // -(instancetype _Nonnull)initWithEmail:(NSString * _Nonnull)email;
        [Export ("initWithEmail:")]
        IntPtr Constructor (string email);
    }

    // @interface DKContactUsItem : NSObject
    [BaseType (typeof(NSObject))]
    interface DKContactUsItem
    {
        // @property (readonly, nonatomic) NSString * identifier;
        [Export ("identifier")]
        string Identifier { get; }

        // -(instancetype)initWithIdentifer:(NSString *)identifier;
        [Export ("initWithIdentifer:")]
        IntPtr Constructor (string identifier);
    }

    // @interface DKContactUsInputTextItem : DKContactUsItem <UITextInputTraits>
    [BaseType (typeof(DKContactUsItem))]
    interface DKContactUsInputTextItem : IUITextInputTraits
    {
        // @property (nonatomic) NSAttributedString * text;
        [Export ("text", ArgumentSemantic.Assign)]
        NSAttributedString Text { get; set; }

        // @property (nonatomic) NSAttributedString * placeholderText;
        [Export ("placeholderText", ArgumentSemantic.Assign)]
        NSAttributedString PlaceholderText { get; set; }

        // @property (readonly, nonatomic) BOOL required;
        [Export ("required")]
        bool Required { get; }

        // @property (nonatomic) UITextAutocapitalizationType autocapitalizationType;
        [Export ("autocapitalizationType", ArgumentSemantic.Assign)]
        UITextAutocapitalizationType AutocapitalizationType { get; set; }

        // @property (nonatomic) UITextAutocorrectionType autocorrectionType;
        [Export ("autocorrectionType", ArgumentSemantic.Assign)]
        UITextAutocorrectionType AutocorrectionType { get; set; }

        // @property (nonatomic) UITextSpellCheckingType spellCheckingType;
        [Export ("spellCheckingType", ArgumentSemantic.Assign)]
        UITextSpellCheckingType SpellCheckingType { get; set; }

        // @property (nonatomic) BOOL enablesReturnKeyAutomatically;
        [Export ("enablesReturnKeyAutomatically")]
        bool EnablesReturnKeyAutomatically { get; set; }

        // @property (nonatomic) UIKeyboardAppearance keyboardAppearance;
        [Export ("keyboardAppearance", ArgumentSemantic.Assign)]
        UIKeyboardAppearance KeyboardAppearance { get; set; }

        // @property (nonatomic) UIKeyboardType keyboardType;
        [Export ("keyboardType", ArgumentSemantic.Assign)]
        UIKeyboardType KeyboardType { get; set; }

        // @property (nonatomic) UIReturnKeyType returnKeyType;
        [Export ("returnKeyType", ArgumentSemantic.Assign)]
        UIReturnKeyType ReturnKeyType { get; set; }

        /*
        // @property (getter = isSecureTextEntry, nonatomic) BOOL secureTextEntry;
        [Export ("secureTextEntry")]
        bool SecureTextEntry { [Bind ("isSecureTextEntry")] get; set; }*/

        // -(instancetype)initWithIdentifier:(NSString *)identifier text:(NSAttributedString *)text placeHolderText:(NSAttributedString *)placeholder required:(BOOL)required;
        [Export ("initWithIdentifier:text:placeHolderText:required:")]
        IntPtr Constructor (string identifier, NSAttributedString text, NSAttributedString placeholder, bool required);
    }

    // TODO - I think here on down had issues with objective sharpie... they didn't really find the classes then....
    // @interface DSAPICase
    [BaseType (typeof(NSObject))]
    interface DSAPICase
    {
        // +(id)listCasesWithParameters:(id)parameters client:(id)client queue:(id)queue success:(id)success failure:(id)failure;
        //[Static]
        [Export ("listCasesWithParameters:client:queue:success:failure:")]
        NSObject ListCasesWithParameters (NSObject parameters, NSObject client, NSObject queue, NSObject success, NSObject failure);

        // +(id)listCasesWithParameters:(id)parameters client:(id)client queue:(id)queue success:(id)success notModified:(id)notModified failure:(id)failure;
        //[Static]
        [Export ("listCasesWithParameters:client:queue:success:notModified:failure:")]
        NSObject ListCasesWithParameters (NSObject parameters, NSObject client, NSObject queue, NSObject success, NSObject notModified, NSObject failure);

        // +(id)searchCasesWithParameters:(id)parameters client:(id)client queue:(id)queue success:(id)success failure:(id)failure;
        //[Static]
        [Export ("searchCasesWithParameters:client:queue:success:failure:")]
        NSObject SearchCasesWithParameters (NSObject parameters, NSObject client, NSObject queue, NSObject success, NSObject failure);

        // +(id)searchCasesWithParameters:(id)parameters client:(id)client queue:(id)queue success:(id)success notModified:(id)notModified failure:(id)failure;
        //[Static]
        [Export ("searchCasesWithParameters:client:queue:success:notModified:failure:")]
        NSObject SearchCasesWithParameters (NSObject parameters, NSObject client, NSObject queue, NSObject success, NSObject notModified, NSObject failure);

        // +(id)createCase:(id)caseDict client:(id)client queue:(id)queue success:(void (^)(DSAPICase *))success failure:(id)failure;
        //[Static]
        [Export ("createCase:client:queue:success:failure:")]
        NSObject CreateCase (NSObject caseDict, NSObject client, NSObject queue, Action<DSAPICase> success, NSObject failure);

        // +(id)showById:(id)caseId parameters:(id)parameters client:(id)client queue:(id)queue success:(void (^)(DSAPICase *))success failure:(id)failure;
        //[Static]
        [Export ("showById:parameters:client:queue:success:failure:")]
        NSObject ShowById (NSObject caseId, NSObject parameters, NSObject client, NSObject queue, Action<DSAPICase> success, NSObject failure);

        // -(id)showWithParameters:(id)parameters queue:(id)queue success:(void (^)(DSAPICase *))success failure:(id)failure;
        [Export ("showWithParameters:queue:success:failure:")]
        NSObject ShowWithParameters (NSObject parameters, NSObject queue, Action<DSAPICase> success, NSObject failure);

        // -(id)updateWithDictionary:(id)dictionary queue:(id)queue success:(void (^)(DSAPICase *))success failure:(id)failure;
        [Export ("updateWithDictionary:queue:success:failure:")]
        NSObject UpdateWithDictionary (NSObject dictionary, NSObject queue, Action<DSAPICase> success, NSObject failure);

        // -(id)showMessageWithParameters:(id)parameters queue:(id)queue success:(void (^)(DSAPIInteraction *))success failure:(id)failure;
        [Export ("showMessageWithParameters:queue:success:failure:")]
        NSObject ShowMessageWithParameters (NSObject parameters, NSObject queue, Action<DSAPIInteraction> success, NSObject failure);

        // -(id)listRepliesWithParameters:(id)parameters queue:(id)queue success:(id)success failure:(id)failure;
        [Export ("listRepliesWithParameters:queue:success:failure:")]
        NSObject ListRepliesWithParameters (NSObject parameters, NSObject queue, NSObject success, NSObject failure);

        // -(id)listRepliesWithParameters:(id)parameters queue:(id)queue success:(id)success notModified:(id)notModified failure:(id)failure;
        [Export ("listRepliesWithParameters:queue:success:notModified:failure:")]
        NSObject ListRepliesWithParameters (NSObject parameters, NSObject queue, NSObject success, NSObject notModified, NSObject failure);

        // -(id)listFeedWithParameters:(id)parameters queue:(id)queue success:(id)success failure:(id)failure;
        [Export ("listFeedWithParameters:queue:success:failure:")]
        NSObject ListFeedWithParameters (NSObject parameters, NSObject queue, NSObject success, NSObject failure);

        // -(id)listFeedWithParameters:(id)parameters queue:(id)queue success:(id)success notModified:(id)notModified failure:(id)failure;
        [Export ("listFeedWithParameters:queue:success:notModified:failure:")]
        NSObject ListFeedWithParameters (NSObject parameters, NSObject queue, NSObject success, NSObject notModified, NSObject failure);

        // -(id)createReply:(id)replyDict queue:(id)queue success:(void (^)(DSAPIInteraction *))success failure:(id)failure;
        [Export ("createReply:queue:success:failure:")]
        NSObject CreateReply (NSObject replyDict, NSObject queue, Action<DSAPIInteraction> success, NSObject failure);

        // -(id)createDraft:(id)draftDict queue:(id)queue success:(void (^)(DSAPIInteraction *))success failure:(id)failure;
        [Export ("createDraft:queue:success:failure:")]
        NSObject CreateDraft (NSObject draftDict, NSObject queue, Action<DSAPIInteraction> success, NSObject failure);

        // -(id)showDraftWithParameters:(id)parameters queue:(id)queue success:(void (^)(DSAPIInteraction *))success failure:(id)failure;
        [Export ("showDraftWithParameters:queue:success:failure:")]
        NSObject ShowDraftWithParameters (NSObject parameters, NSObject queue, Action<DSAPIInteraction> success, NSObject failure);

        // -(id)listNotesWithParameters:(id)parameters queue:(id)queue success:(id)success failure:(id)failure;
        [Export ("listNotesWithParameters:queue:success:failure:")]
        NSObject ListNotesWithParameters (NSObject parameters, NSObject queue, NSObject success, NSObject failure);

        // -(id)listNotesWithParameters:(id)parameters queue:(id)queue success:(id)success notModified:(id)notModified failure:(id)failure;
        [Export ("listNotesWithParameters:queue:success:notModified:failure:")]
        NSObject ListNotesWithParameters (NSObject parameters, NSObject queue, NSObject success, NSObject notModified, NSObject failure);

        // -(id)createNote:(id)noteDict queue:(id)queue success:(void (^)(DSAPINote *))success failure:(id)failure;
        [Export ("createNote:queue:success:failure:")]
        NSObject CreateNote (NSObject noteDict, NSObject queue, Action<DSAPINote> success, NSObject failure);

        // -(id)listAttachmentsWithParameters:(id)parameters queue:(id)queue success:(id)success failure:(id)failure;
        [Export ("listAttachmentsWithParameters:queue:success:failure:")]
        NSObject ListAttachmentsWithParameters (NSObject parameters, NSObject queue, NSObject success, NSObject failure);

        // -(id)listAttachmentsWithParameters:(id)parameters queue:(id)queue success:(id)success notModified:(id)notModified failure:(id)failure;
        [Export ("listAttachmentsWithParameters:queue:success:notModified:failure:")]
        NSObject ListAttachmentsWithParameters (NSObject parameters, NSObject queue, NSObject success, NSObject notModified, NSObject failure);

        // -(id)createAttachment:(id)attachmentDict queue:(id)queue success:(void (^)(DSAPIAttachment *))success failure:(id)failure;
        [Export ("createAttachment:queue:success:failure:")]
        NSUrlSessionDataTask CreateAttachment (NSDictionary attachmentDict, NSOperationQueue queue, Action<DSAPIAttachment> success, DSAPIFailureBlock failure);

        // -(id)historyWithQueue:(id)queue success:(id)success failure:(id)failure;
        [Export ("historyWithQueue:success:failure:")]
        NSObject HistoryWithQueue (NSObject queue, NSObject success, NSObject failure);

        // -(id)historyWithQueue:(id)queue success:(id)success notModified:(id)notModified failure:(id)failure;
        [Export ("historyWithQueue:success:notModified:failure:")]
        NSObject HistoryWithQueue (NSObject queue, NSObject success, NSObject notModified, NSObject failure);

        // -(id)previewMacros:(id)macros queue:(id)queue success:(id)success failure:(id)failure;
        [Export ("previewMacros:queue:success:failure:")]
        NSObject PreviewMacros (NSObject macros, NSObject queue, NSObject success, NSObject failure);
    }

    // @interface DSAPIAttachment
    [BaseType (typeof(NSObject))]
    interface DSAPIAttachment
    {
        // -(id)showWithParameters:(id)parameters queue:(id)queue success:(void (^)(DSAPIAttachment *))success failure:(id)failure;
        [Export ("showWithParameters:queue:success:failure:")]
        NSObject ShowWithParameters (NSObject parameters, NSObject queue, Action<DSAPIAttachment> success, NSObject failure);

        // +(NSString*)getASLLogMessages
        [Static]
        [ExportAttribute ("getASLLogMessages:")]
        NSArray GetASLLogMessages(NSString appName);
    }

    // @interface DSAPINote
    [BaseType (typeof(NSObject))]
    interface DSAPINote
    {
        // -(id)showWithParameters:(id)parameters queue:(id)queue success:(void (^)(DSAPINote *))success failure:(id)failure;
        [Export ("showWithParameters:queue:success:failure:")]
        NSObject ShowWithParameters (NSObject parameters, NSObject queue, Action<DSAPINote> success, NSObject failure);
    }

    // @interface DSAPIInteraction
    [BaseType (typeof(NSObject))]
    interface DSAPIInteraction
    {
        // -(id)showWithParameters:(id)parameters queue:(id)queue success:(void (^)(DSAPIInteraction *))success failure:(id)failure;
        [Export ("showWithParameters:queue:success:failure:")]
        NSObject ShowWithParameters (NSObject parameters, NSObject queue, Action<DSAPIInteraction> success, NSObject failure);

        // -(id)createAttachment:(id)attachmentDict queue:(id)queue success:(void (^)(DSAPIAttachment *))success failure:(id)failure;
        [Export ("createAttachment:queue:success:failure:")]
        NSObject CreateAttachment (NSObject attachmentDict, NSObject queue, Action<DSAPIAttachment> success, NSObject failure);

        // -(id)updateWithDictionary:(id)dictionary queue:(id)queue success:(void (^)(DSAPIInteraction *))success failure:(id)failure;
        [Export ("updateWithDictionary:queue:success:failure:")]
        NSObject UpdateWithDictionary (NSObject dictionary, NSObject queue, Action<DSAPIInteraction> success, NSObject failure);
    }
}

