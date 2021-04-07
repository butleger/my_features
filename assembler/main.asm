format ELF64 
public _start

include "asmlib/io.inc"
include "asmlib/sys.inc"
include "asmlib/str.inc"
include "asmlib/algo.inc"
include "asmlib/math.inc"

section '.bss' writable
buffer_size equ 21
buffer db buffer_size

section '.data' writable
filename db "test.txt", 0
message db "fuck you damn ass", 0xA, 0
message_size = $ - message

section '.text' executable
_start:
	mov rax, filename
	mov rbx, 777o
	call fcreate
	mov rbx, message
	mov rcx, message_size
	call fwrite
	;call dw_rand
	;call print_number
	;call endl
	;call dw_rand
	;call print_number
	;call endl
	;call dw_rand
	;call print_number
	;call endl
	call exit
