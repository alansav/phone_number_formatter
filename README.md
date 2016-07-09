# phone_number

This project is a .NET Core class library.

This project is designed to help developers when working with phone numbers which users may enter in a variety of formats, and provides helper methods to clean the phone number into a standard and consistent format.

##Usage

`Install-Package PhoneNumber`

If the user enters a mobile number as a single string and specified the default country code to be +44 then calling ToInternationalFormat will display the number in the standard number for international dialling. Note the leading is dropped.

```
var phoneNumber = new Savage.Formatters.PhoneNumber("07712345678", "+44");
Console.WriteLine(phoneNumber.ToInternationalFormat()); // +44 7712345678
```

If the user enters a landline number as a single string with a space between the area code and their phone number:
```
var phoneNumber = new Savage.Formatters.PhoneNumber("01234 123456", "+44");
Console.WriteLine(phoneNumber2.ToInternationalFormat()); // +44 (1234) 123456
```

If the user enters a landline number as above but places brackets around the area code the international format is formatted the same
```
var phoneNumber = new Savage.Formatters.PhoneNumber("(01234) 123456", "+44");
Console.WriteLine(phoneNumber3.ToInternationalFormat()); // +44 (1234) 123456
```