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
namespace HexaVerticalSlice.BC.FeedDisplay.Tests.Acceptance.Features
{
    using Reqnroll;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class LoginToMyAccountFeature : object, Xunit.IClassFixture<LoginToMyAccountFeature.FixtureData>, Xunit.IAsyncLifetime
    {
        
        private static global::Reqnroll.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "LoginToMyAccount.feature"
#line hidden
        
        public LoginToMyAccountFeature(LoginToMyAccountFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
        }
        
        public static async System.Threading.Tasks.Task FeatureSetupAsync()
        {
            testRunner = global::Reqnroll.TestRunnerManager.GetTestRunnerForAssembly(null, global::Reqnroll.xUnit.ReqnrollPlugin.XUnitParallelWorkerTracker.Instance.GetWorkerId());
            global::Reqnroll.FeatureInfo featureInfo = new global::Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Login to my account", "As a user\nI want to login to my account\nIn order to use the app", global::Reqnroll.ProgrammingLanguage.CSharp, featureTags);
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
#line 7
#line hidden
#line 8
    await testRunner.GivenAsync("the current date is 2024-07-12", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
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
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Cannot log in with invalid email")]
        [Xunit.TraitAttribute("FeatureTitle", "Login to my account")]
        [Xunit.TraitAttribute("Description", "Cannot log in with invalid email")]
        [Xunit.TraitAttribute("Category", "ErrorHandling")]
        [Xunit.InlineDataAttribute("test", new string[0])]
        [Xunit.InlineDataAttribute("test@", new string[0])]
        [Xunit.InlineDataAttribute("test@company", new string[0])]
        public async System.Threading.Tasks.Task CannotLogInWithInvalidEmail(string invalidEmail, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "ErrorHandling"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("Invalid email", invalidEmail);
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Cannot log in with invalid email", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 11
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 7
await this.FeatureBackgroundAsync();
#line hidden
                global::Reqnroll.Table table7 = new global::Reqnroll.Table(new string[] {
                            "Field",
                            "Value"});
                table7.AddRow(new string[] {
                            "Email address",
                            string.Format("{0}", invalidEmail)});
                table7.AddRow(new string[] {
                            "Password",
                            "P@ssword!"});
#line 12
    await testRunner.WhenAsync("I log in with", ((string)(null)), table7, "When ");
#line hidden
#line 16
    await testRunner.ThenAsync("a bad request error occurred with type BadEmailAddressFormat and message \"The pro" +
                        "vided email has a bad format.\"", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Cannot log in with unknown user")]
        [Xunit.TraitAttribute("FeatureTitle", "Login to my account")]
        [Xunit.TraitAttribute("Description", "Cannot log in with unknown user")]
        [Xunit.TraitAttribute("Category", "ErrorHandling")]
        public async System.Threading.Tasks.Task CannotLogInWithUnknownUser()
        {
            string[] tagsOfScenario = new string[] {
                    "ErrorHandling"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Cannot log in with unknown user", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 24
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 7
await this.FeatureBackgroundAsync();
#line hidden
                global::Reqnroll.Table table8 = new global::Reqnroll.Table(new string[] {
                            "Field",
                            "Value"});
                table8.AddRow(new string[] {
                            "Email address",
                            "unknown@test.com"});
                table8.AddRow(new string[] {
                            "Password",
                            "P@ssword!"});
#line 25
    await testRunner.WhenAsync("I log in with", ((string)(null)), table8, "When ");
#line hidden
#line 29
    await testRunner.ThenAsync("an unauthorized error occurred with type LoginFailed and message \"Incorrect user " +
                        "or password\"", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Cannot log in with invalid password")]
        [Xunit.TraitAttribute("FeatureTitle", "Login to my account")]
        [Xunit.TraitAttribute("Description", "Cannot log in with invalid password")]
        [Xunit.TraitAttribute("Category", "ErrorHandling")]
        public async System.Threading.Tasks.Task CannotLogInWithInvalidPassword()
        {
            string[] tagsOfScenario = new string[] {
                    "ErrorHandling"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Cannot log in with invalid password", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 32
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 7
await this.FeatureBackgroundAsync();
#line hidden
                global::Reqnroll.Table table9 = new global::Reqnroll.Table(new string[] {
                            "Field",
                            "Value"});
                table9.AddRow(new string[] {
                            "Email address",
                            "john.doe@mycompany.com"});
                table9.AddRow(new string[] {
                            "Password",
                            "P@ssw0rd!"});
#line 33
    await testRunner.GivenAsync("I am registered with", ((string)(null)), table9, "Given ");
#line hidden
                global::Reqnroll.Table table10 = new global::Reqnroll.Table(new string[] {
                            "Field",
                            "Value"});
                table10.AddRow(new string[] {
                            "Email address",
                            "john.doe@mycompany.com"});
                table10.AddRow(new string[] {
                            "Password",
                            "P@ssword!!!!!"});
#line 37
    await testRunner.WhenAsync("I log in with", ((string)(null)), table10, "When ");
#line hidden
#line 41
    await testRunner.ThenAsync("an unauthorized error occurred with type LoginFailed and message \"Incorrect user " +
                        "or password\"", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Log in to my account allows me to use the app for 90 days")]
        [Xunit.TraitAttribute("FeatureTitle", "Login to my account")]
        [Xunit.TraitAttribute("Description", "Log in to my account allows me to use the app for 90 days")]
        public async System.Threading.Tasks.Task LogInToMyAccountAllowsMeToUseTheAppFor90Days()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Log in to my account allows me to use the app for 90 days", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 43
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 7
await this.FeatureBackgroundAsync();
#line hidden
                global::Reqnroll.Table table11 = new global::Reqnroll.Table(new string[] {
                            "Field",
                            "Value"});
                table11.AddRow(new string[] {
                            "Email address",
                            "john.doe@mycompany.com"});
                table11.AddRow(new string[] {
                            "Password",
                            "P@ssw0rd!"});
#line 44
    await testRunner.GivenAsync("I am registered with", ((string)(null)), table11, "Given ");
#line hidden
                global::Reqnroll.Table table12 = new global::Reqnroll.Table(new string[] {
                            "Field",
                            "Value"});
                table12.AddRow(new string[] {
                            "Email address",
                            "john.doe@mycompany.com"});
                table12.AddRow(new string[] {
                            "Password",
                            "P@ssw0rd!"});
#line 48
     await testRunner.WhenAsync("I log in with", ((string)(null)), table12, "When ");
#line hidden
#line 52
    await testRunner.ThenAsync("I can now use the app until the 2024-10-10", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
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
                await LoginToMyAccountFeature.FeatureSetupAsync();
            }
            
            async System.Threading.Tasks.Task Xunit.IAsyncLifetime.DisposeAsync()
            {
                await LoginToMyAccountFeature.FeatureTearDownAsync();
            }
        }
    }
}
#pragma warning restore
#endregion
