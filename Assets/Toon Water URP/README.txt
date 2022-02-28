Hello, thank you for purchasing my asset!
If you have questions or problems please let me know at piotrtplaystore@gmail.com

Setup:
I) Make sure you have URP version at least 7.2.1 (it will work on older version but shadow problem can occur when using cascades) to do so:
    1. Go to Package Manager
    2. Search for Universal RP on the list
    3. If your version if under 7.2.1:
        - Click on Universal RP
        - Click the arrow on the left side to show more options
        - Click on newer version number that just showed 
        - Click 'Update to <verion_you_selected>' on the right side under description of package

II) Now we have to make sure that depth texture and opaque texture option is enabled:
    1. Go to your URP settings files (usually they should be in the folder called Settings folder in the Project inspector)
    2. In every settings file (UniversalRP-HighQuality, UniversalRP-LowQuality, UniversalRP-MediumQuality) 
    make sure option called Depth Texture and option called Opaque Texture is checked (you can leave the second setting disabled if don't want refractions)
    3. When you enabled Opaque Texture option you can see you can choose Opaque Downsampling option 4x Bilinear is the fastest but will result in pixelated refractions, 
    None is the slowest but will make refractions look the best. Setting this option is up to you and your performance preferences.

III) Create material or apply premade by me Toon Water Material to surface that should be water in your scene! 

IV) Done I hope you will like my asset. Remember to write me an email if you have any problems. 

If you like my asset don't forget to write a review it helps me and my future customers a lot :)!
    
Useful pieces of information:
- When Fresnel Power is set to 0 it means Fresnel effect is disabled
- To control the transparency of the water use alpha values of Shallow and Deep watercolor
- Specular Edges Smoothness Factor - is used to smooth out the edges of toon specular highlight however setting this value too big will make your highlight look not sharp
- Use Refraction In Depth Based Water Color - decide whether depth gradient should also wave or be static