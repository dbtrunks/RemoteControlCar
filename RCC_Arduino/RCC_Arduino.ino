#include <ESP8266WiFi.h>
#include <WiFiUdp.h>

const char* ssid = ""; // "podaæ";
const char* password = ""; //"podaæ";
int ledPin = 2; // D4
int ledPin2 = 12; // D6

WiFiUDP UDPTestServer;
unsigned int UDPPort = 2807;

const int packetSize = 1;
byte packetBuffer[packetSize];
char comChar;
void setup() {
	Serial.begin(115200);
	delay(10);

	pinMode(ledPin, OUTPUT);
	digitalWrite(ledPin, LOW);
	pinMode(ledPin2, OUTPUT);
	digitalWrite(ledPin2, LOW);

	Serial.println();
	Serial.println();
	Serial.print("Connecting to ");
	Serial.println(ssid);

	WiFi.begin(ssid, password);
	WiFi.config(IPAddress(192, 168, 33, 60), IPAddress(192, 168, 33, 1), IPAddress(255, 255, 255, 0));

	while (WiFi.status() != WL_CONNECTED) {
		delay(500);
		Serial.print(".");
	}

	Serial.println("");
	Serial.println("WiFi connected");
	Serial.println("IP address: ");
	Serial.println(WiFi.localIP());

	UDPTestServer.begin(UDPPort);

}

int value = 0;

void loop() {
	handleUDPServer();
	delay(1);
}

void handleUDPServer() {
	int cb = UDPTestServer.parsePacket();
	if (cb) {
		UDPTestServer.read(packetBuffer, packetSize);
		String myData = "";
		for (int i = 0; i < packetSize; i++) {
			myData += (char)packetBuffer[i];
		}
		Serial.println(myData);

		comChar = myData.charAt(0);


		switch (comChar) {
		case 'A':
			digitalWrite(ledPin, HIGH);
			break;
		case 'D':
			digitalWrite(ledPin2, HIGH);
			break;
		default:
			digitalWrite(ledPin, LOW);
			digitalWrite(ledPin2, LOW);
			break;
		}
	}
}