# AE_Menu
�ŋ߂�AE��script�ŊȒP�Ƀ��j���[�����`���[���ƃt�H���g�̎w�肪�ł��Ȃ��̂ŕ��������������Đh���ł��B  
���ƌ�����CEP�Ńp�b�P�[�W���̂����낢��ʓ|�Ȃ̂ō�������j���[�쐬�A�v���ł��B 
  
�t�H���_���ɂ���X�N���v�g�ƃv���Z�b�g��ǂݎ���ĕ��������̃T���l�C���摜���쐬���āAiconbutton�Ń��X�g�\�������܂��B
�摜�Ȃ̂ŕ����T�C�Y�����R�ɐݒ�ł��܂��B  
  
�Ђ�����ȒP�Ƀ��j���[�����`���[������悤�ɍH�v���Ă���܂��B  
��{�ƂȂ�X�N���v�g�̓��[�U�[������ɕҏW�\�ł��B  
  
## �g����
* �K���ɃX�N���v�g���܂Ƃ߂��t�H���_�����܂��B<br>scripts�t�H���_���ɍ��ꍇ��()�ł������ēǂݍ��܂Ȃ��悤�ɂ��Ă����Ɗy�ł��B
* ���̃t�H���_�����̃A�v���Ƀh���b�O&�h���b�v����ƃX�N���v�g�t�@�C�������j���[�Ƃ��ĕ\������܂��B
* �E�N���b�N����ExportScript�����s����ƁA�����̃X�N���v�g���Ăяo�����j���[�X�N���v�g�������o����܂��B  
  
��{�I�Ɉȏ�̑���Ń��j���[���ł��܂��B

## ������ƃJ�X�^�}�C�Y
�E�N���b�N���j���[�ňȉ��̎����o���܂��B
* SelectDir  �X�N���v�g�t�H���_��I�ԃ_�C�A���O�̕\���B�h���b�O&�h���b�v�̕����y�ł��B
* EditPalette EditPalette��\�����܂��B���Ő������܂��B
* EditCaption �\������Ă���e�L�X�g��ύX���܂��B
* EditCellColor �I���������ڂ̂ݔw�i�F��ς��܂��B
* EditFont �t�H���g�̕ύX���s���܂��B
* CopyColor �I���������ڂ̔w�i�F���R�s�[���܂��B
* PasteColor �I���������ڂ֔w�i�F���y�[�X�g���܂��B
* SizeSetteing �I���������ڂ̃T�C�Y��ύX���܂��B
* EditMenuTitle �E�B���h�E�ɕ\�������e�L�X�g��ύX���܂��B
* Clear ���������܂��B
* AllColor ���ׂĂ̍��ڂ̔w�i�F�𓯂��F�ɕύX���܂��B
* ExportScript ���j���[�X�N���v�g�������o���܂��B
* ExportPict �T���l�C���摜�̂ݏ����o���܂��B
* Exit ���̃A�v�����I�����܂��B

�w�i�F�́A���ڂ�jsx/jsxbin/ffx�ŐF��ς���悤�ɂ��Ă��܂��B

�E�N���b�N����EditPalette��I�ԂƊȒP�ȑ���p���b�g���J���܂��B
* UP �I�������������ڂ���Ɉړ�
* DOWN �I�������������ڂ����Ɉړ�
�c��͉E�N���b�N�̂��̂Ɠ����ł��B  
  
���̃��j���[�̃X�^�C���̐ݒ�͕ۑ�����܂���B  
���ۂ̂Ƃ��낱���ōׂ��Ȓ������s�����A�����o�������X�N���v�g���C�����������y�ő����̂ł�����𐄏��ł��B  

## ���x�Ȏg����
���̃��j���[�A�v�������s�����exe�t�@�C���Ɠ����ꏊ�ɓ�����jsx�t�@�C���������o���܂��B  
ExportScript�����s���鎞�͂���jsx�t�@�C�����e���v���[�g�Ƃ��ď����o�����s���܂��̂ŁA�Ȃ񂩂������炱����C���ł��B  
�C�����ړ���jsx��ǂ�ł��������B

## �����o���ꂽ�X�N���v�g��ҏW
�����o���ꂽ�X�N���v�g�͈ȉ��̂悤�ɂȂ�܂��B
```
(function(me){
	//----------------------------------
	// ���j���[�ɕ\�������^�C�g��
	var scriptName = "�ȒP���j���[";
	//----------------------------------
	//�ǂݍ��ރt�H���_
	var cmdItemsPathBase = "./(�ȒP���j���[)";
	//�ǂݍ��ރX�N���v�g��
	var cmdItemsPath =[
"�V���v�����ߌ�3_CS6.ffx",
"�V���v�����ߌ�3_�ӂ��u���V_CS6.ffx",
"�V���v�����ߌ�3_�e���T��_CS6.ffx",
"�V���v�����ߌ�3_���~��_CS6.ffx",
"�V���v�����ߌ�3_������_CS6.ffx"
	];
	// �A�C�R���T�C�Y
	var iconWidth = 240; 
	var iconHeight = 20; 

	var scrolBarWidth = 30;
// �ȉ��ȗ�
})(this);
```

cmdItemsPathBase�ϐ��̓��e�����������邱�ƂŐ�΃p�X�E���΃p�X��ǂݍ��ރt�H���_����ύX�ł��܂��B
cmdItemsPath�z�񂪎��ۂ̃X�N���v�g�EFFX�̃t�@�C�����ł��B�����ŏ����Ƃ������ł��܂��B

## Dependency
Visual studio 2019 C#


## Setup

## License
This software is released under the MIT License, see LICENSE

## Authors

bry-ful(Hiroshi Furuhashi)  
twitter:[bryful](https://twitter.com/bryful)  
bryful@gmail.com  

## References
