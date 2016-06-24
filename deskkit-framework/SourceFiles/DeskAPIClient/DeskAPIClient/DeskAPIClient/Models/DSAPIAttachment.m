//
//  DSAPIAttachment.m
//  DeskAPIClient
//
//  Created by Desk.com on 9/25/13.
//  Copyright (c) 2015, Salesforce.com, Inc.
//  All rights reserved.
//
//  Redistribution and use in source and binary forms, with or without modification, are permitted provided
//  that the following conditions are met:
//
//     Redistributions of source code must retain the above copyright notice, this list of conditions and the
//     following disclaimer.
//
//     Redistributions in binary form must reproduce the above copyright notice, this list of conditions and
//     the following disclaimer in the documentation and/or other materials provided with the distribution.
//
//     Neither the name of Salesforce.com, Inc. nor the names of its contributors may be used to endorse or
//     promote products derived from this software without specific prior written permission.
//
//  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED
//  WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
//  PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR
//  ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED
//  TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
//  HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
//  NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
//  POSSIBILITY OF SUCH DAMAGE.
//

#import "DSAPIAttachment.h"
#import "DSAPIClient.h"
#import "asl.h"

#define kClassName @"attachment"

@implementation DSAPIAttachment

+ (NSString *)className
{
    return kClassName;
}

- (NSURLSessionDataTask *)showWithParameters:(NSDictionary *)parameters
                                       queue:(NSOperationQueue *)queue
                                     success:(void (^)(DSAPIAttachment *note))success
                                     failure:(DSAPIFailureBlock)failure
{
    return [super showWithParameters:parameters
                               queue:queue
                             success:^(DSAPIResource *resource) {
                                 if (success) {
                                     success((DSAPIAttachment *)resource);
                                 }
                             }
                             failure:failure];
}

// TODO - put this somewhere of our own??
// http://stackoverflow.com/questions/6144347/using-objective-c-to-read-log-messages-posted-to-the-device-console
// https://www.cocoanetics.com/2011/03/accessing-the-ios-system-log/
+(NSArray*)getASLLogMessages:(NSString*)appName
{
    NSMutableArray *logMessages = [NSMutableArray new];
    
    aslmsg q, m;
    int i;
    const char *key, *val;
    
    //int davidTemp = 0;
    
    q = asl_new(ASL_TYPE_QUERY);
    asl_set_query(q, ASL_KEY_SENDER, [appName UTF8String], ASL_QUERY_OP_EQUAL);
    
    //asdf
    // TODO - AudioAddictiOSDI probably
    //asl_set_query(q, ASL_KEY_SENDER, "MyApp", ASL_QUERY_OP_EQUAL);
    // Will be needed to filter, then we probably want to only grab the last 200 or so?? What makes it less choppy?? Or maybe it can be in the background??
    
    aslresponse r = asl_search(NULL, q);
    while (NULL != (m = asl_next(r)))
    {
        //NSMutableDictionary *tmpDict = [NSMutableDictionary dictionary];
        
        for (i = 0; (NULL != (key = asl_key(m, i))); i++)
        {
            NSString *keyString = [NSString stringWithUTF8String:(char *)key];
            
            val = asl_get(m, key);
            
            NSString *string = val?[NSString stringWithUTF8String:val]:@"";
            if([keyString isEqualToString:@"Message"])
            {
                [logMessages addObject:string];
            }
            //[tmpDict setObject:string forKey:keyString];
        }
        
        //NSLog(@"%@", tmpDict);
        /*
        if([tmpDict[@"Sender"] isEqualToString:@"AudioAddictiOSDI"]) {
            
        }*/
    }
    asl_release(r);
    
    //NSLog(@"All Done");
    
    return logMessages;
}

@end
