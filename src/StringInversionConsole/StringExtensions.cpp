#include "StringExtensions.h"

#include <memory>
#include <ostream>
#include <vector>

#include "StringInversion.h"

std::string StringExtensions::inverse_string(const std::string& string_to_inverse)
{
	std::vector<char> vector(string_to_inverse.begin(), string_to_inverse.end());
	vector.push_back('\0');
	const auto buffer = std::make_unique<char*>(&vector[0]);
	
	const auto code = InverseString64(*buffer);
	
	return std::string(*buffer);
}
