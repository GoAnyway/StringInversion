#include <iostream>

#include "StringExtensions.h"

int main()
{
	std::cout << "Write any word you want to inverse:\n" << std::endl;
	std::string some_string;
	std::cin >> some_string;
	const auto some_string_inversed = StringExtensions::inverse_string(some_string);
	
	std::cout << "\nYour inversed string: " << some_string_inversed << std::endl;
	
	std::cout << "\nWrite any character to close." << std::endl;
	std::string mes;
	std::cin >> mes;
	
	return 0;
}