format ELF64 
public _start

include "asmlib/io.inc"
include "asmlib/sys.inc"
include "asmlib/str.inc"
include "asmlib/algo.inc"


section '.data' writable
array db 5,4,3,2,1
array_size = 5
buffer_size equ 20
buffer rb buffer_size

section '.text' executable
fmt db "%s%s"
first db 1
second db 2
number db "1234", 0
_start:
	mov rax, buffer
	mov rbx, buffer_size 
	call input_number
	;mov rax, number
	;call string_to_number
	call print_number
	call exit
