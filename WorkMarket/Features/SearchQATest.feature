Feature: SearchQATest

Scenario: SearchTest_01 Verify each search result on the Find talent page includes the search phrase
Given User is logged in
And User Searches for "Test" on the Find Talent Page
Then Each returned search result should contain the search phrase "Test" 
