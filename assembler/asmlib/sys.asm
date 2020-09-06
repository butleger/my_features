format ELF64

public exit

extrn print_string

section '.exit' executable
exit :
	mov rax, 1
	mov rbx, 0
	int 0x80
