﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by Reqnroll (https://www.reqnroll.net/).
//      Reqnroll Version:2.0.0.0
//      Reqnroll Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace HexaVerticalSlice.Api.Tests.Acceptance.BCs.FeedComputation.Features
{
    using Reqnroll;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class CommentAPostFeature : object, Xunit.IClassFixture<CommentAPostFeature.FixtureData>, Xunit.IAsyncLifetime
    {
        
        private static global::Reqnroll.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "CommentAPost.feature"
#line hidden
        
        public CommentAPostFeature(CommentAPostFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
        }
        
        public static async System.Threading.Tasks.Task FeatureSetupAsync()
        {
            testRunner = global::Reqnroll.TestRunnerManager.GetTestRunnerForAssembly(null, global::Reqnroll.xUnit.ReqnrollPlugin.XUnitParallelWorkerTracker.Instance.GetWorkerId());
            global::Reqnroll.FeatureInfo featureInfo = new global::Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "BCs/FeedComputation/Features", "Comment a post", "In order to give my option on a post\nAs a user of the feed computation bc\nI want " +
                    "to comment a post", global::Reqnroll.ProgrammingLanguage.CSharp, featureTags);
            await testRunner.OnFeatureStartAsync(featureInfo);
        }
        
        public static async System.Threading.Tasks.Task FeatureTearDownAsync()
        {
            string testWorkerId = testRunner.TestWorkerId;
            await testRunner.OnFeatureEndAsync();
            testRunner = null;
            global::Reqnroll.xUnit.ReqnrollPlugin.XUnitParallelWorkerTracker.Instance.ReleaseWorker(testWorkerId);
        }
        
        public async System.Threading.Tasks.Task TestInitializeAsync()
        {
        }
        
        public async System.Threading.Tasks.Task TestTearDownAsync()
        {
            await testRunner.OnScenarioEndAsync();
        }
        
        public void ScenarioInitialize(global::Reqnroll.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public async System.Threading.Tasks.Task ScenarioStartAsync()
        {
            await testRunner.OnScenarioStartAsync();
        }
        
        public async System.Threading.Tasks.Task ScenarioCleanupAsync()
        {
            await testRunner.CollectScenarioErrorsAsync();
        }
        
        public virtual async System.Threading.Tasks.Task FeatureBackgroundAsync()
        {
#line 6
#line hidden
#line 7
    await testRunner.GivenAsync("I am registered and logged in as john@company.com", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
            global::Reqnroll.Table table10 = new global::Reqnroll.Table(new string[] {
                        "Email address"});
            table10.AddRow(new string[] {
                        "emma@company.com"});
#line 8
    await testRunner.AndAsync("I connected the following users", ((string)(null)), table10, "And ");
#line hidden
        }
        
        async System.Threading.Tasks.Task Xunit.IAsyncLifetime.InitializeAsync()
        {
            await this.TestInitializeAsync();
        }
        
        async System.Threading.Tasks.Task Xunit.IAsyncLifetime.DisposeAsync()
        {
            await this.TestTearDownAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="By default, a post has no thread")]
        [Xunit.TraitAttribute("FeatureTitle", "Comment a post")]
        [Xunit.TraitAttribute("Description", "By default, a post has no thread")]
        public async System.Threading.Tasks.Task ByDefaultAPostHasNoThread()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("By default, a post has no thread", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 12
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 6
await this.FeatureBackgroundAsync();
#line hidden
#line 13
    await testRunner.GivenAsync("a post with title \"My first post\" and content \"This is my first post\" has been pu" +
                        "blished", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 14
    await testRunner.WhenAsync("I get the \"My first post\" post details", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
                global::Reqnroll.Table table11 = new global::Reqnroll.Table(new string[] {
                            "Author",
                            "Comment",
                            "Date"});
#line 15
    await testRunner.ThenAsync("the post has the following threads:", ((string)(null)), table11, "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Commenting a post creates a thread")]
        [Xunit.TraitAttribute("FeatureTitle", "Comment a post")]
        [Xunit.TraitAttribute("Description", "Commenting a post creates a thread")]
        public async System.Threading.Tasks.Task CommentingAPostCreatesAThread()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Commenting a post creates a thread", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 18
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 6
await this.FeatureBackgroundAsync();
#line hidden
#line 19
    await testRunner.GivenAsync("the current date is 2024-09-30", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 20
    await testRunner.AndAsync("a post with title \"My first post\" and content \"This is my first post\" has been pu" +
                        "blished", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 21
    await testRunner.WhenAsync("I publish a comment \"Nice post\" on the \"My first post\" post", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 22
    await testRunner.AndAsync("I get the \"My first post\" post details", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
                global::Reqnroll.Table table12 = new global::Reqnroll.Table(new string[] {
                            "Author",
                            "Comment",
                            "Date"});
                table12.AddRow(new string[] {
                            "john@company.com",
                            "Nice post",
                            "2024-09-30"});
#line 23
    await testRunner.ThenAsync("the post has the following threads:", ((string)(null)), table12, "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : object, Xunit.IAsyncLifetime
        {
            
            async System.Threading.Tasks.Task Xunit.IAsyncLifetime.InitializeAsync()
            {
                await CommentAPostFeature.FeatureSetupAsync();
            }
            
            async System.Threading.Tasks.Task Xunit.IAsyncLifetime.DisposeAsync()
            {
                await CommentAPostFeature.FeatureTearDownAsync();
            }
        }
    }
}
#pragma warning restore
#endregion
