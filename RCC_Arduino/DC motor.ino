//Przyk³ad uruchomienia silnika DC przy wykorzystaniu mostka H L293D

int pinDC1 = 13; //DC1;
int pinDC2 = 12; //DC1;
int pinDC3 = 9; //DC2;
int pinDC4 = 8; //DC2;
void setup() {
	pinMode(pinDC1, OUTPUT);
	pinMode(pinDC2, OUTPUT);
	pinMode(pinDC3, OUTPUT);
	pinMode(pinDC4, OUTPUT);
	digitalWrite(pinDC1, LOW);
	digitalWrite(pinDC2, LOW);
	digitalWrite(pinDC3, LOW);
	digitalWrite(pinDC4, LOW);
}


void loop() {
	digitalWrite(pinDC1, LOW);
	digitalWrite(pinDC3, LOW);
	delay(500);
	digitalWrite(pinDC2, HIGH);
	digitalWrite(pinDC4, HIGH);
	delay(2500);
	digitalWrite(pinDC2, LOW);
	digitalWrite(pinDC4, LOW);
	delay(2500);
	digitalWrite(pinDC1, HIGH);
	digitalWrite(pinDC3, HIGH);
	delay(2500);
}
