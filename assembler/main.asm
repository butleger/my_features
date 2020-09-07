format ELF64 
public _start

include "asmlib/io.inc"
include "asmlib/sys.inc"

section '.text' executable
fmt db "%s%s"
msg1 db "Hello, ", 0x0
msg2 db "World!", 0x0
_start:
	push msg1
	push msg2
	mov rax, fmt
	call printf
	call exit
