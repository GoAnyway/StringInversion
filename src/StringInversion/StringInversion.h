#pragma once

#define STRING_INVERSION_API _declspec(dllexport)

extern "C"
{
	STRING_INVERSION_API int InverseString32(char* buffer);
	STRING_INVERSION_API int InverseString64(char* buffer);
}