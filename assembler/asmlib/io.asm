format ELF64

public endl
public printf
public print_abcd
public print_char
public print_string
public print_number
public print_string_without_endl

include "str.inc"


section '.bss' writable
	bss_char rb 1


section '.printf' executable
;|input;
;	rax = string(format)
;	stack = values
printf:
	push rax
	push rbx
	push rcx
	push rdx

	.next_iter:
		mov rbp, 16
		cmp [rax], byte 0
		je .close
		cmp [rax],byte '%'
		je .special_char
		jmp .default_char
		.special_char:
			inc rax
			cmp [rax], byte 's'
			je .print_string
			.print_string:
				push rax
				mov rax, [rsp + rbx]
				pop rax
				inc rax
				jmp .shift_stack
		.default_char:
			push rax
			mov rax, [rax]
			call print_char
			pop rax	
			inc rax
			jmp .next_step
		.shift_stack:
			add rbx, 8
		.next_step:
			jmp .next_iter
	.close:
		pop rdx
		pop rcx
		pop rbx
		pop rax
		ret



section '.print_number' executable
;| input
;rax = number
print_number:
	push rax
	push rbx
	push rcx
	push rdx

	xor rcx, rcx

	.next_iter:
		mov rbx, 10
		xor rdx, rdx
		div rbx
		add rdx, '0'
		push rdx
		inc rcx
		cmp rax, 0
		je .print_iter
		jmp .next_iter
	
	.print_iter:
		cmp rcx, 0
		je .return
		pop rax
		call print_char
		dec	rcx
		jmp .print_iter

	.return:
		pop rdx
		pop rcx
		pop rbx
		pop rax

		ret


section '.print_abcd'
str_a db "a = ", 0
str_b db "b = ", 0
str_c db "c = ", 0
str_d db "d = ", 0
print_abcd:
	push rax

	call endl

	push rax 
	mov rax, str_a
	call print_string_without_endl
	pop rax
	call print_number
	call endl

	mov rax, str_b
	call print_string_without_endl
	mov rax, rbx
	call print_number
	call endl

	mov rax, str_c
	call print_string_without_endl
	mov rax, rcx
	call print_number
	call endl

	mov rax, str_d
	call print_string_without_endl
	mov rax, rdx
	call print_number
	call endl

	call endl
	pop rax
	ret


;|input :
;rax = string
section '.print_string' executable
print_string:
	push rax
	push rbx
	push rcx
	push rdx

	mov rcx, rax
	call strlen
	mov rdx, rax
	mov rax, 4
	mov rbx, 1
	int 0x80

	call endl

	pop rdx
	pop rcx
	pop rbx
	pop rax

	ret


section '.print_string_without_endl'
;| input 
;	rax = string
print_string_without_endl:
	push rax
	push rbx
	push rcx
	push rdx

	mov rcx, rax
	call strlen
	mov rdx, rax
	mov rax, 4
	mov rbx, 1
	int 0x80

	pop rdx
	pop rcx
	pop rbx
	pop rax

	ret


section '.endl' executable
endl:
	push rax
	mov rax, 0xA
	call print_char
	pop rax

	ret


section '.print_char' executable
;|input:
;rax = char
print_char:
	
	push rax
	push rbx
	push rcx
	push rdx

	mov [bss_char], al

	mov rax, 4
	mov rbx, 1
	mov rcx, bss_char
	mov rdx, 1
	int 0x80

	pop rdx
	pop rcx
	pop rbx
	pop rax

	ret
