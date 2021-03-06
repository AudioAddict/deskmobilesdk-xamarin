//
//  DSAPIListProvider.h
//  DeskAPIClient
//
//  Created by Desk.com on 1/27/15.
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

#import <Foundation/Foundation.h>
#import "DSAPITypes.h"
#import "DSAPIPage.h"

@protocol DSAPIListProviderDelegate, DSAPIListEndpoint;

@interface DSAPIListProvider : NSObject

@property (nonatomic, readonly) NSInteger totalPages;
@property (nonatomic, readonly) NSUInteger resourcesPerPage;
@property (nonatomic, weak) id<DSAPIListProviderDelegate> delegate;
@property (nonatomic, readonly) id<DSAPIListEndpoint> endpoint;

- (instancetype)initWithEndpoint:(id<DSAPIListEndpoint>)endpoint;

- (void)reset;
- (NSInteger)numberOfResourcesOnPageNumber:(NSUInteger)pageNumber;
- (DSAPIResource *)resourceOnPageNumber:(NSUInteger)pageNumber inRow:(NSUInteger)row;

- (void)fetchResourcesOnPageNumber:(NSUInteger)pageNumber;

@end

@protocol DSAPIListProviderDelegate <NSObject>

@optional

- (void)listProvider:(DSAPIListProvider *)listProvider willFetchPageNumber:(NSUInteger)pageNumber;
- (void)listProvider:(DSAPIListProvider *)listProvider didFetchPage:(DSAPIPage *)page;
- (void)listProvider:(DSAPIListProvider *)listProvider fetchDidFailOnPageNumber:(NSUInteger)pageNumber;
- (void)listProviderDidFetchNoResults:(DSAPIListProvider *)listProvider;

@end

@protocol DSAPIListEndpoint <NSObject>

@property (nonatomic) NSUInteger perPage;

- (void)listResourcesOnPageNumber:(NSUInteger)pageNumber
                            queue:(NSOperationQueue *)queue
                          success:(DSAPIPageSuccessBlock)success
                          failure:(DSAPIFailureBlock)failure;

@end
