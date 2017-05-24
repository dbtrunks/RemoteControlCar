#include <ESP8266WiFi.h> 
#include <WiFiUdp.h> 

WiFiUDP Udp;

const char *APssid = "RCC";
const char *APpassword = "123rcc"; 
IPAddress APlocal_IP(192, 168, 4, 1);
IPAddress APgateway(192, 168, 4, 1);
IPAddress APsubnet(255, 255, 255, 0);
int motorDC1pin1 = 5; // D1
int motorDC1pin2 = 4; // D2
int motorDC2pin1 = 14; //D5
int motorDC2pin2 = 12; //D6


//const char *STAssid = "SSID"; 
// char *STApassword = "PASSWORD";
IPAddress STAlocal_IP(192, 168, 0, 27);
IPAddress STAgateway(192, 168, 0, 1);
IPAddress STAsubnet(255, 255, 255, 0);

unsigned int localUdpPort = 4210;
char incomingPacket[255];
char replyPacket[] = "";
char comChar;


void setup() {
	Serial.begin(115200); 
	pinMode(motorDC1pin1, OUTPUT);
	digitalWrite(motorDC1pin1, LOW);
	pinMode(motorDC1pin2, OUTPUT);
	digitalWrite(motorDC1pin2, LOW);
	pinMode(motorDC2pin1, OUTPUT);
	digitalWrite(motorDC2pin1, LOW);
	pinMode(motorDC2pin2, OUTPUT);
	digitalWrite(motorDC2pin2, LOW);

	WiFi.mode(WIFI_AP_STA);

	Serial.println("ESP8266 System test");
	Serial.print("Soft-AP configuration ... ");
	Serial.println(WiFi.softAPConfig(APlocal_IP, APgateway, APsubnet) ? "OK" : "Failed!"); 
	Serial.print("Setting soft-AP ... ");
	//Serial.println(WiFi.softAP(APssid, APpassword) ? "OK" : "Failed!");
	Serial.print("Soft-AP IP address = ");
	Serial.println(WiFi.softAPIP()); 

	
	//Serial.printf("Station connecting to %s\n", STAssid);
	//WiFi.begin(STAssid, STApassword);
	//WiFi.config(STAlocal_IP, STAgateway, STAsubnet);
	//while (WiFi.status() != WL_CONNECTED)
	//{
	//delay(500);
	//Serial.print(".");
									 //}
	Serial.println();
	Serial.print("Station connected, IP address: ");
	Serial.println(WiFi.localIP());
	Serial.printf("Signal Strength: %d dBm\n", WiFi.RSSI());

	Serial.println("begin UDP port");
	Udp.begin(localUdpPort);
	Serial.print("local UDP port: ");
	Serial.println(localUdpPort);


}

void loop() {

	int packetSize = Udp.parsePacket();
	if (packetSize)
	{

		int len = Udp.read(incomingPacket, 255);
		if (len > 0)
		{
			incomingPacket[len] = 0;

			comChar = incomingPacket[0];
			Serial.println(comChar);
			switch (comChar) {
			case 'U':
				digitalWrite(motorDC1pin2, LOW);
				digitalWrite(motorDC1pin1, HIGH);
				break;
			case 'D':
				digitalWrite(motorDC1pin1, LOW);
				digitalWrite(motorDC1pin2, HIGH);
				break;
			case 'L':
				digitalWrite(motorDC2pin2, LOW);
				digitalWrite(motorDC2pin1, HIGH);
				break;
			case 'R':
				digitalWrite(motorDC2pin1, LOW);
				digitalWrite(motorDC2pin2, HIGH);
				break;
			default:
				digitalWrite(motorDC1pin1, LOW);
				digitalWrite(motorDC1pin2, LOW);
				digitalWrite(motorDC2pin1, LOW);
				digitalWrite(motorDC2pin2, LOW);
				break;
			}
		}

	}

}
