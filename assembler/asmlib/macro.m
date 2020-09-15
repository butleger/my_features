macro push_abcd
{
	push rax
	push rbx
	push rcx
	push rdx
}

macro pop_dcba
{
	pop rdx
	pop rcx
	pop rbx
	pop rax
}

macro push_abc
{
	push rax
	push rbx
	push rcx
}

macro pop_cba
{
	pop rcx
	pop rbx
	pop rax
}

macro push_bcd
{
	push rbx
	push rcx
	push rdx
}

macro pop_dcb
{
	pop rdx
	pop rcx
	pop rbx
}