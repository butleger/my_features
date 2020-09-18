format ELF64

public number_to_string
public string_to_number
public reverse_string
public strlen

include "macro.m"
include "io.inc"

section '.strlen'
;|input:
;rax = string
;|output: 
;rax = number
strlen:
	push rbx

	xor rbx, rbx

	.next_iter:
		cmp byte [rax + rbx], 0
		je .return
		inc rbx
		jmp .next_iter

	.return:
		mov rax, rbx
		pop rbx
		ret


;|input:
; rax = number
; rbx = string(buffer for result)
;|output:
; rax = string(result)
section '.number_to_string' executable
number_to_string:

	push_bcd

	xor rcx, rcx
	mov rdi, 10

	.next_iter:
		div rdi
		cmp rdx, 0
		jne .continue
		cmp rax, 0
		jne .continue
		jmp .making_string
		.continue:
			push rdx
			inc rcx
		jmp .next_iter

	.making_string:
		mov rax, rbx
		xor rbx, rbx

		._next_iter:
			cmp rcx, rbx
			je .return
			pop rdx
			add rdx, '0'
			mov byte [rax + rbx], dl
			inc rbx
			jmp ._next_iter

	.return:
		mov byte [rax + rbx], 0

		pop_dcb

		ret


;|input: 
; rax = string
;|output:
; rax = string
section '.reverse_string' executable
reverse_string:
	push_bcd

	mov rbx, rax 
	call strlen
	mov rcx, rax
	mov rax, rbx
	mov	rbx, rcx
	xor rcx, rcx
	dec rbx

	.next_iter:
		cmp rbx, rcx
		je	.return 
		dec rbx
		cmp rbx, rcx
		je	.return 
		inc rbx
		
		push rdx
		mov rsi, rcx 
			mov dl, byte [rax + rsi]
			mov cl, byte [rax + rbx] 
			mov byte [rax + rbx], dl
			mov byte [rax + rsi], cl
		mov rcx, rsi
		pop rdx
		
		inc rcx
		dec rbx
		jmp .next_iter 

	.return:
		pop_dcb
		ret  


section '.string_to_number' executable
; |input
;	rax = string
; |output:
;	rax = number
string_to_number:
	push_bcd
	
	mov rcx, rax
	xor rax, rax; here will be chars
	xor rbx, rbx; counter
	xor rdx, rdx; result
	.next_iter:
		cmp [rcx + rbx], byte 0
		je .close
		mov al, [rcx + rbx]
		sub al, '0'
		imul rdx, 10
		add dl, al
		inc rbx
		jmp .next_iter
	.close:
		mov rax, rdx
		pop_dcb
		ret

