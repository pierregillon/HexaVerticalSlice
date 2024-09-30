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
namespace HexaVerticalSlice.Api.Tests.Acceptance.BCs.Networking.Features
{
    using Reqnroll;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class AcceptAnInvitationFeature : object, Xunit.IClassFixture<AcceptAnInvitationFeature.FixtureData>, Xunit.IAsyncLifetime
    {
        
        private static global::Reqnroll.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "AcceptAnInvitation.feature"
#line hidden
        
        public AcceptAnInvitationFeature(AcceptAnInvitationFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
        }
        
        public static async System.Threading.Tasks.Task FeatureSetupAsync()
        {
            testRunner = global::Reqnroll.TestRunnerManager.GetTestRunnerForAssembly(null, global::Reqnroll.xUnit.ReqnrollPlugin.XUnitParallelWorkerTracker.Instance.GetWorkerId());
            global::Reqnroll.FeatureInfo featureInfo = new global::Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "BCs/Networking/Features", "Accept an invitation", "In order to join the connections of a user and to add a user to my connections\nAs" +
                    " a user of the networking bc\nI want to accept an invitation I have received", global::Reqnroll.ProgrammingLanguage.CSharp, featureTags);
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
#line 8
    await testRunner.AndAsync("emma@company.com has registered", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
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
        
        [Xunit.SkippableFactAttribute(DisplayName="By default, my invitations list is empty")]
        [Xunit.TraitAttribute("FeatureTitle", "Accept an invitation")]
        [Xunit.TraitAttribute("Description", "By default, my invitations list is empty")]
        public async System.Threading.Tasks.Task ByDefaultMyInvitationsListIsEmpty()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("By default, my invitations list is empty", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 10
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
                global::Reqnroll.Table table12 = new global::Reqnroll.Table(new string[] {
                            "Invited profile",
                            "Request date"});
#line 11
    await testRunner.ThenAsync("my invitations list is", ((string)(null)), table12, "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="An invitation to connect with another user is listed")]
        [Xunit.TraitAttribute("FeatureTitle", "Accept an invitation")]
        [Xunit.TraitAttribute("Description", "An invitation to connect with another user is listed")]
        public async System.Threading.Tasks.Task AnInvitationToConnectWithAnotherUserIsListed()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("An invitation to connect with another user is listed", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 14
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
#line 15
    await testRunner.GivenAsync("the current date is 2024-09-25", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 16
    await testRunner.WhenAsync("I invite emma@company.com to connect with", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
                global::Reqnroll.Table table13 = new global::Reqnroll.Table(new string[] {
                            "Invited profile",
                            "Request date"});
                table13.AddRow(new string[] {
                            "emma@company.com",
                            "2024-09-25"});
#line 17
    await testRunner.ThenAsync("my invitations list is", ((string)(null)), table13, "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Once a request is accepted, the invitation is removed from the list")]
        [Xunit.TraitAttribute("FeatureTitle", "Accept an invitation")]
        [Xunit.TraitAttribute("Description", "Once a request is accepted, the invitation is removed from the list")]
        public async System.Threading.Tasks.Task OnceARequestIsAcceptedTheInvitationIsRemovedFromTheList()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Once a request is accepted, the invitation is removed from the list", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 21
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
#line 22
    await testRunner.GivenAsync("I invited emma@company.com to connect with", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 23
    await testRunner.WhenAsync("emma@company.com accepts my invitation", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
                global::Reqnroll.Table table14 = new global::Reqnroll.Table(new string[] {
                            "User",
                            "Request date"});
#line 24
    await testRunner.ThenAsync("my invitations list is", ((string)(null)), table14, "Then ");
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
                await AcceptAnInvitationFeature.FeatureSetupAsync();
            }
            
            async System.Threading.Tasks.Task Xunit.IAsyncLifetime.DisposeAsync()
            {
                await AcceptAnInvitationFeature.FeatureTearDownAsync();
            }
        }
    }
}
#pragma warning restore
#endregion
