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
    public partial class RegisterANewUserFeature : object, Xunit.IClassFixture<RegisterANewUserFeature.FixtureData>, Xunit.IAsyncLifetime
    {
        
        private static global::Reqnroll.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "RegisterNewUser.feature"
#line hidden
        
        public RegisterANewUserFeature(RegisterANewUserFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
        }
        
        public static async System.Threading.Tasks.Task FeatureSetupAsync()
        {
            testRunner = global::Reqnroll.TestRunnerManager.GetTestRunnerForAssembly(null, global::Reqnroll.xUnit.ReqnrollPlugin.XUnitParallelWorkerTracker.Instance.GetWorkerId());
            global::Reqnroll.FeatureInfo featureInfo = new global::Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Register a new user", "As a user\nI want to register\nIn order to use the app", global::Reqnroll.ProgrammingLanguage.CSharp, featureTags);
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
    await testRunner.GivenAsync("the current date is 2022-10-23", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
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
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Cannot register a user with an invalid email")]
        [Xunit.TraitAttribute("FeatureTitle", "Register a new user")]
        [Xunit.TraitAttribute("Description", "Cannot register a user with an invalid email")]
        [Xunit.TraitAttribute("Category", "ErrorHandling")]
        [Xunit.InlineDataAttribute("test", new string[0])]
        [Xunit.InlineDataAttribute("test@", new string[0])]
        [Xunit.InlineDataAttribute("test@company", new string[0])]
        public async System.Threading.Tasks.Task CannotRegisterAUserWithAnInvalidEmail(string invalidEmail, string[] exampleTags)
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
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Cannot register a user with an invalid email", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
#line 12
    await testRunner.WhenAsync(string.Format("I register with email \"{0}\"", invalidEmail), ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 13
    await testRunner.ThenAsync("a bad request error occurred with type BadEmailAddressFormat and message \"The pro" +
                        "vided email has a bad format.\"", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Cannot register a user with a weak password")]
        [Xunit.TraitAttribute("FeatureTitle", "Register a new user")]
        [Xunit.TraitAttribute("Description", "Cannot register a user with a weak password")]
        [Xunit.TraitAttribute("Category", "ErrorHandling")]
        [Xunit.InlineDataAttribute("te!", new string[0])]
        [Xunit.InlineDataAttribute("aaa", new string[0])]
        [Xunit.InlineDataAttribute("...", new string[0])]
        [Xunit.InlineDataAttribute("d", new string[0])]
        public async System.Threading.Tasks.Task CannotRegisterAUserWithAWeakPassword(string weakPassword, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "ErrorHandling"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("Weak password", weakPassword);
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Cannot register a user with a weak password", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 22
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
#line 23
    await testRunner.WhenAsync(string.Format("I register with password \"{0}\"", weakPassword), ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 24
    await testRunner.ThenAsync("a bad request error occurred with type TooWeakPassword and message \"The provided " +
                        "password is too weak.\"", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Registering a user allows me to use the app for 90 days")]
        [Xunit.TraitAttribute("FeatureTitle", "Register a new user")]
        [Xunit.TraitAttribute("Description", "Registering a user allows me to use the app for 90 days")]
        public async System.Threading.Tasks.Task RegisteringAUserAllowsMeToUseTheAppFor90Days()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Registering a user allows me to use the app for 90 days", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 33
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
#line 34
    await testRunner.GivenAsync("the token validity is 90 days", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
                global::Reqnroll.Table table13 = new global::Reqnroll.Table(new string[] {
                            "Field",
                            "Value"});
                table13.AddRow(new string[] {
                            "Email address",
                            "john.doe@mycompany.com"});
                table13.AddRow(new string[] {
                            "Password",
                            "P@ssw0rd!"});
#line 35
    await testRunner.WhenAsync("I register and log in with", ((string)(null)), table13, "When ");
#line hidden
#line 39
    await testRunner.ThenAsync("I can now use the app until the 2023-01-21", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="After registered, I can log in")]
        [Xunit.TraitAttribute("FeatureTitle", "Register a new user")]
        [Xunit.TraitAttribute("Description", "After registered, I can log in")]
        public async System.Threading.Tasks.Task AfterRegisteredICanLogIn()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("After registered, I can log in", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 41
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
                global::Reqnroll.Table table14 = new global::Reqnroll.Table(new string[] {
                            "Field",
                            "Value"});
                table14.AddRow(new string[] {
                            "Email address",
                            "john.doe@mycompany.com"});
                table14.AddRow(new string[] {
                            "Password",
                            "P@ssw0rd!"});
#line 42
    await testRunner.GivenAsync("I am registered with", ((string)(null)), table14, "Given ");
#line hidden
                global::Reqnroll.Table table15 = new global::Reqnroll.Table(new string[] {
                            "Field",
                            "Value"});
                table15.AddRow(new string[] {
                            "Email address",
                            "john.doe@mycompany.com"});
                table15.AddRow(new string[] {
                            "Password",
                            "P@ssw0rd!"});
#line 46
     await testRunner.WhenAsync("I log in with", ((string)(null)), table15, "When ");
#line hidden
#line 50
    await testRunner.ThenAsync("I can now use the app until the 2023-01-21", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
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
                await RegisterANewUserFeature.FeatureSetupAsync();
            }
            
            async System.Threading.Tasks.Task Xunit.IAsyncLifetime.DisposeAsync()
            {
                await RegisterANewUserFeature.FeatureTearDownAsync();
            }
        }
    }
}
#pragma warning restore
#endregion
