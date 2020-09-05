format ELF64 
public _start


section '.data'
	msg db "hello, world!", 0
	len = $-msg
	buffer.size equ 3
	new_line equ 0xA
	num db "123", 0	

section '.bss' writable
	bss_char rb 1
	buffer rb 20


section '.text' executable

_start:
	mov rax, msg 
	call print_string
	call reverse_string
	call print_string
	mov rax, 123
	mov rbx, buffer
	call number_to_string
;	call print_string
	call exit


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


section '.endl' executable

	endl:
		push rax
		mov rax, new_line
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


;|input:
; rax = number
; rbx = string(buffer for result)
;|output:
; rax = string(result)
section '.number_to_string' executable

number_to_string:
	
	push rax
	start db "start number_to_string", 0
	mov rax, start
	call print_string
	pop rax

	push rbx
	push rcx
	push rdx

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

		push rax
		mov rax, rcx
		call print_number
		call endl
		pop rax

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

		pop rdx
		pop rcx
		pop rbx

		ret


;|input: 
; rax = string
;|output:
; rax = string
section '.reverse_string' executable
reverse_string:
	push rbx
	push rcx
	push rdx

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
		pop rdx
		pop rcx
		pop rbx
		
		ret  


;| input
;rax = number
section '.print_number'
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




;|input:
;rax = string
;|output: 
;rax = number
section '.strlen'
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


section '.exit' executable
exit :
	mov	rax, 1
	mov rbx, 0
	int 0x80