# AE_utils
Adobe After Effects�ō�Ƃ������y�ɂ��邽�߂̏����c�[���ނł��B  
��{�I�ɒP�ƃA�v���ł����A������ƂŊy�ɂȂ�悤�Ƀt���[�e�B���O�o�[���t���Ă��܂��B
  
�\�[�X����΂킩��悤�ɏ����Â��₵�Ă����܂��B  
  
## ���ʂ̎g����
���ʂ̃A�v���ł��̂ŁA�K���ȂƂ���ɃC���X�g�[�����Ď��s���Ă��������B

## �ʂ̉��

### AE_ColorPalette.exe
���ɂ����J���[�p���b�g�ł��B  
  
![AE_ColorPalette](https://user-images.githubusercontent.com/50650451/77540762-047ca600-6ee7-11ea-8511-bfb290b8dcec.png)  
�J���[�v���p�e�B��I�����āA�R�s�[���y�[�X�g�ł��܂��B  
���肻���łȂ������̂ō��܂����B�ʏ�̃R���|�W�b�g���ł͂��܂�g��Ȃ��Ǝv���܂����A�V�F�C�v�Ńf�U�C�����Ă鎞�ɏd�󂵂܂��B  
  
���܂ŐV�K�r���[�ŉ摜���J���Ă���Ă܂������A����ł����ł���������ʂ������͗L���Ɏg����悤�ɂȂ�܂��B  
  
### AE_Expression_CopyPaste
�P���ɃR�s�[�����e�L�X�g�𒙂߂邱�Ƃ��ł���A�v���ł��B  
AE��ŃR�s�[�������̂͂قڑS�ăe�L�X�g�f�[�^�ɂȂ��Ă���̂ŁAAE�̃p�����[�^�𒙂߂Ă������Ƃ��ł��܂��B  
  
![AE_Expression_CopyPaste](https://user-images.githubusercontent.com/50650451/77541340-e499b200-6ee7-11ea-8b97-3b56ab59546f.png)  
  
�l�΃G�N�X�v���b�V�����ł悭�g���R�[�h���𒙂߂Ă��܂��B

### aeclip.exe
![aeclip exe](https://user-images.githubusercontent.com/50650451/77542192-25de9180-6ee9-11ea-97a0-ccb8ef3a6fee.png)  
����̓R���\�[���A�v���ł��B  
aeclip.exe  
         aeclip [/c] filename (copy to clipboard.)  
         aeclip [/p] (from clipboard to STD default)  
         aeclip [/o] filename (from clipboard to file)  
         aeclip  /h or /? (help)  
  
�w�肵���e�L�X�g�t�@�C�����N���b�v�{�[�h�ɑ�������A�N���b�v�{�[�h�̒��g���o�͂ł��܂��B
AE�X�N���v�g���ŃN���b�v�{�[�h���g�������Ƃ��Ɏg���܂��B  
�K���ȃe�L�X�g�t�@�C���������o����  
 
 system.callSystem("aeclip foo.txt");  
  
�Ƃ����Ďg���܂��B���ۂ̃T���v���R�[�h�͈ȉ��̂悤�ɂȂ�܂��B
```
	var aeclipPath = File.decode($.fileName.getParent()+"/aeclip.exe");//getParent()�͎���v���g�^�C�v
	//���s�X�N���v�g�t�@�C���Ɠ����ꏊ��aeclip��u�����Ƃ���
	var toClipbord = function(str)
	{
		var ob = Folder.temp.fullName;
		var pa =  ob + "/tmp.txt";
		var ff = new File(pa);
		ff.encoding = "utf-8";
		if (ff.open("w")){
			try{
				ff.write(str);
			}finally{
				ff.close();
			}
		}
		var fclip = new File(aeclipPath);
		var cmd =  "\"" + fclip.fsName +"\"" + " /c \"" + ff.fsName + "\"";
		if (ff.exists==true){
			try{
				var er = system.callSystem(cmd);
			}catch(e){
				alert("ca" + e.toString());
			}
		}

	}
```
## Dependency
Visual studio 2017 C#


## Setup

## License
This software is released under the MIT License, see LICENSE

## Authors

bry-ful(Hiroshi Furuhashi) http://bryful.yuzu.bz/  
twitter:[bryful](https://twitter.com/bryful)  
bryful@gmail.com  

## References
