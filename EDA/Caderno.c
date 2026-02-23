#include <stdlib.h>



int main(){

	float x = 10.5;
	float *ptr = &x;

    imprimir(*ptr);
    return 0;

}


void swap(int *x, int*y){

    int temp = *x;

    *x = *y;

    *y = temp;
}

void imprimir(float *a){

	printf("valor %f\n",*a);
	printf("morada %p\n",a);
	
}



