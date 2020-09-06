format ELF64 
public _start

extrn gcd
extrn exit
extrn endl
extrn print_number
extrn print_string

section '.text' executable
msg db "Linker and assembler is working!", 0x0
_start:
	mov rax, msg
	call print_string
	call exit
