Shader "Custom/RainbowShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Time ("Time", Range (0, 1)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _MainTex;
        float _Time;

        struct Input
        {
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            // Define rainbow gradient colors
            float4 rainbowColors[7];
            rainbowColors[0] = float4(1, 0, 0, 1);    // Red
            rainbowColors[1] = float4(1, 0.5, 0, 1);  // Orange
            rainbowColors[2] = float4(1, 1, 0, 1);    // Yellow
            rainbowColors[3] = float4(0, 1, 0, 1);    // Green
            rainbowColors[4] = float4(0, 0, 1, 1);    // Blue
            rainbowColors[5] = float4(0.29, 0, 0.51, 1); // Indigo
            rainbowColors[6] = float4(0.5, 0, 1, 1);  // Violet

            // Calculate rainbow color based on time
            float t = _Time * 2 * 3.14159; // Map time to 0-2*pi
            int colorIndex = int(sin(t) * 3 + 3); // Use sin wave to cycle through colors
            float4 rainbowColor = rainbowColors[colorIndex];

            // Output rainbow color
            o.Albedo = rainbowColor.rgb;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
