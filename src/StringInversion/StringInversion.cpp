#include "StringInversion.h"

#include <cstring>

int inverse_string(char* buffer);

extern "C"
{
	STRING_INVERSION_API int InverseString32(char* buffer)
	{
		return inverse_string(buffer);
	}

	STRING_INVERSION_API int InverseString64(char* buffer)
	{
		return inverse_string(buffer);
	}
}

int inverse_string(char* buffer)
{
	const auto buffer_length = strlen(buffer);
	if (buffer_length == 0 ||
		buffer_length == 1 ||
		buffer_length > 100)
	{
		return 666;
	}

	for (unsigned int n = 0; n < buffer_length / 2; ++n)
	{
		buffer[n] ^= buffer[buffer_length - n - 1];
		buffer[buffer_length - n - 1] ^= buffer[n];
		buffer[n] ^= buffer[buffer_length - n - 1];
	}

	return 777;
}