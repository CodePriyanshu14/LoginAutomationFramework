@login
Feature: Login Functionality

As a user
I want to validate different login scenarios
So that the authentication functionality works correctly

@InvalidEmail
Scenario: Login with Invalid Email Format
B
    Given User is on the Login page
    When User loads test data "InvalidEmail"
    And User enters email from Excel
    And User enters password from Excel
    And User clicks the Login button
    Then User should see invalid email message "Email is not valid."

@InvalidUsername
Scenario: Login with Invalid Username

    Given User is on the Login page
    When User loads test data "InvalidUsername"
    And User enters email from Excel
    And User enters password from Excel
    And User clicks the Login button
    Then User should see wrong credentials message "Wrong email or password"

@InvalidPassword
Scenario: Login with Invalid Password

    Given User is on the Login page
    When User loads test data "InvalidPassword"
    And User enters email from Excel
    And User enters password from Excel
    And User clicks the Login button
    Then User should see wrong credentials message "Wrong email or password"

@ForgotPassword
Scenario: Forgot Password

    Given User is on the Login page
    When User loads test data "ForgotPassword"
    And User clicks Forgot Password
    And User enters email from Excel
    And User submits Forgot Password request
    Then User should see confirmation message "Check Your Email"